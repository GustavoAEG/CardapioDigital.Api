using CardapioDigital.Application.DTOs;
using CardapioDigital.Domain.Entities;
using CardapioDigital.Domain.Interfaces;
using CardapioDigital.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CardapioDigital.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IJWTService _jwt;
        private readonly IPasswordService _passwordService;

        public AuthController(AppDbContext db, IJWTService jwt,IPasswordService passwordService)
        {
            _db = db;
            _jwt = jwt;
            _passwordService = passwordService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var user = await _db.Users
                .FirstOrDefaultAsync(u => u.Email == request.Email);

            if (user == null)
                return Unauthorized();

            if (user.PasswordHash != request.Password) // depois trocarr por hash
                return Unauthorized();

            var roles = await _db.UserRoles
                .Where(ur => ur.UserId == user.Id)
                .Join(
                    _db.Roles,
                    ur => ur.RoleId,
                    r => r.Id,
                    (ur, r) => r.Name
                )
                .ToListAsync();

            var token = _jwt.GenerateToken(
                user.Id,
                user.RestaurantId,
                roles
            );

            return Ok(new LoginResponse(
                token,
                DateTime.UtcNow.AddMinutes(60)
            ));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var hash = _passwordService.Hash(request.Password);

            var user = new User(
                request.RestaurantID,
                request.RestaurantName,
                request.Email,
                hash
            );

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            return Ok();
        }



    }

}

using CardapioDigital.Application.Services;
using CardapioDigital.Domain.Interfaces;
using CardapioDigital.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRCoder;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace CardapioDigital.Api.Controllers.Admin
{
    [ApiController]
    [Authorize] // JWT
    [Route("admin/restaurants/{rid:guid}/tables")]
    public class TablesController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly ITokenService _tokenService;

        public static class Roles
        {
            public static readonly Guid Admin =
                Guid.Parse("11111111-1111-1111-1111-111111111111");

            public static readonly Guid Waiter =
                Guid.Parse("22222222-2222-2222-2222-222222222222");

            public static readonly Guid Kitchen =
                Guid.Parse("33333333-3333-3333-3333-333333333333");
        }


        public TablesController(AppDbContext db, ITokenService tokenService)
        {
            _db = db;
            _tokenService = tokenService;
        }

        [HttpPost("{tid:guid}/rotate-token")]
        public async Task<IActionResult> RotateToken(
            Guid rid,
            Guid tid,
            [FromQuery] bool returnQrImage = false, // opcional: ?returnQrImage=true
            CancellationToken cancellationToken = default)
        {
            // 1) validar user logado
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.FindFirst("sub")?.Value;
            if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out var userId))
                return Forbid();

            // 2) validar que user é admin do restaurante rid
            var isAdmin = await _db.UserRoles.AnyAsync(ur =>
                ur.UserId == userId &&
                ur.RoleId == Roles.Admin, cancellationToken);
            if (!isAdmin)
                return Forbid();

            // opcional: confirmar que o admin pertence ao restaurant (se sua model exigir)
            var user = await _db.Users.FindAsync(new object[] { userId }, cancellationToken);
            if (user == null || user.RestaurantId != rid)
                return Forbid();

            // 3) carregar mesa
            var table = await _db.Tables
                .Where(t => t.Id == tid && t.RestaurantId == rid)
                .FirstOrDefaultAsync(cancellationToken);

            if (table == null)
                return NotFound();

            // 4) gerar token e hash
            var token = _tokenService.GenerateToken(32); // tamanho customizável
            var hash = _tokenService.HashToken(token);
            var expiresAt = DateTime.UtcNow.AddDays(30);

            // 5) aplicar no aggregate
            table.SetTokenHash(hash, expiresAt);
            await _db.SaveChangesAsync(cancellationToken);

            // 6) montar url segura (só retorna para admin)
            var qrUrl = $"https://app.yoursaas.com/public/menu?rid={rid}&tid={tid}&t={token}";

            // 7) opcional: gerar PNG base64 do QR
            string? qrBase64 = null;
            if (returnQrImage)
            {
                using var qrGenerator = new QRCodeGenerator();
                using var data = qrGenerator.CreateQrCode(qrUrl, QRCodeGenerator.ECCLevel.Q);
                using var qrCode = new PngByteQRCode(data);
                var pngBytes = qrCode.GetGraphic(20);
                qrBase64 = Convert.ToBase64String(pngBytes);
            }

            // 8) retornar token e url (token só para admin)
            return Ok(new
            {
                token,
                qrUrl,
                qrBase64 // null se não foi pedido
            });
        }
    }
}

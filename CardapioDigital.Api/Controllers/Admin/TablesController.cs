using CardapioDigital.Api.Authorization;
using CardapioDigital.Domain.Interfaces;
using CardapioDigital.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRCoder;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace CardapioDigital.Api.Controllers.Admin
{
    [ApiController]
    [Route("admin/restaurants/{rid:guid}/tables")]
    [Authorize(Policy = Policies.RequireRestaurantAdmin)]
    public class TablesController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly ITableTokenService _tokenService;

        public TablesController(AppDbContext db, ITableTokenService tokenService)
        {
            _db = db;
            _tokenService = tokenService;
        }

        [HttpPost("{tid:guid}/rotate-token")]
        public async Task<IActionResult> RotateToken(
            Guid rid,
            Guid tid,
            [FromQuery] bool returnQrImage = false,
            CancellationToken cancellationToken = default)
        {
            // 1️⃣ pegar rid do token
            var tokenRestaurantId = User.FindFirstValue("rid");

            if (tokenRestaurantId == null || tokenRestaurantId != rid.ToString())
                return Forbid(); // token não pertence a esse restaurante

            // 2️⃣ carregar mesa
            var table = await _db.Tables
                .FirstOrDefaultAsync(
                    t => t.Id == tid && t.RestaurantId == rid,
                    cancellationToken
                );

            if (table == null)
                return NotFound("Mesa não registrada neste restaurante.");

            // 3️⃣ gerar token da mesa
            var token = _tokenService.GenerateToken(32);
            var hash = _tokenService.HashToken(token);
            var expiresAt = DateTime.UtcNow.AddDays(30);

            table.SetTokenHash(hash, expiresAt);
            await _db.SaveChangesAsync(cancellationToken);

            // 4️⃣ gerar URL do QR
            var qrUrl =
                $"https://app.yoursaas.com/public/menu?rid={rid}&tid={tid}&t={token}";

            // 5️⃣ QR opcional
            string? qrBase64 = null;
            if (returnQrImage)
            {
                using var qrGenerator = new QRCodeGenerator();
                using var data = qrGenerator.CreateQrCode(qrUrl, QRCodeGenerator.ECCLevel.Q);
                using var qrCode = new PngByteQRCode(data);
                qrBase64 = Convert.ToBase64String(qrCode.GetGraphic(20));
            }

            return Ok(new
            {
                qrUrl,
                qrBase64
            });
        }
    }
}

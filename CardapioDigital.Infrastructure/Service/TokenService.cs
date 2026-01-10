using CardapioDigital.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace CardapioDigital.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly string _salt;

        public TokenService(IConfiguration configuration)
        {
            _salt = configuration["Token:Salt"]
                ?? throw new InvalidOperationException("Token:Salt not configured");
        }

        public string GenerateToken(int length = 32)
        {
            var bytes = RandomNumberGenerator.GetBytes(length);
            return Convert.ToBase64String(bytes)
                .Replace("+", "")
                .Replace("/", "")
                .Replace("=", "")
                .Substring(0, length);
        }

        public byte[] HashToken(string token)
        {
            using var sha = SHA256.Create();
            var input = Encoding.UTF8.GetBytes(token + _salt);
            return sha.ComputeHash(input);
        }
    }
}

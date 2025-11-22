using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Application.Services
{
    public class TokenService
    {
        private readonly string _salt;
        public TokenService(IConfiguration cfg) => _salt = cfg["Token:Salt"];

        public string GenerateToken(int length = 10)
        {   
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            var random = new byte[length];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(random);

            var result = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                result.Append(chars[random[i] % chars.Length]);
            }

            return result.ToString();
        }
        public string HashToken(string token)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(token + _salt);
            return Convert.ToHexString(sha.ComputeHash(bytes));
        }

        public bool VerifyToken(string token, string storedHash)
            => HashToken(token) == storedHash;
    }

}

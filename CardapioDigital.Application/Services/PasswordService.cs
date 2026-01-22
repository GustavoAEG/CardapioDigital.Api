using CardapioDigital.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Application.Services
{
    public class PasswordService : IPasswordService
    {
        public string Hash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool verify(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }

    }
}


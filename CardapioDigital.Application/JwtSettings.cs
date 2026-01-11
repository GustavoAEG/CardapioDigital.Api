using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Application.DTOs
{
    namespace CardapioDigital.Application.Settings
    {
        public class JwtSettings
        {
            public string Issuer { get; set; } = null!;
            public string Audience { get; set; } = null!;
            public string Secret { get; set; } = null!;
            public int ExpiresMinutes { get; set; }
        }
    }

}

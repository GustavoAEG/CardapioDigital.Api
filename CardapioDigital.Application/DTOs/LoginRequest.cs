using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Application.DTOs
{
    public record LoginRequest(string Email, string Password);

    public record LoginResponse(
        string AccessToken,
        DateTime ExpiresAtUtc
    );

}

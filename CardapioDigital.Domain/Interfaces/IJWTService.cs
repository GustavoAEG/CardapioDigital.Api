using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Domain.Interfaces
{
    public interface IJWTService
    {
        string GenerateToken(Guid userId, Guid restaurantId, IEnumerable<string> roles);
    }
}

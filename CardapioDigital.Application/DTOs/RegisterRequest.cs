using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Application.DTOs
{
    public class RegisterRequest
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string? RestaurantName { get; set; }
        public Guid RestaurantID { get; set; }
        }
}

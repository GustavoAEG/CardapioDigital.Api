using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Domain.Entities;

public class Tax
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid RestaurantId { get; private set; }
    public string Code { get; private set; }
    public string Name { get; private set; }
    public decimal? Rate { get; private set; }   // pode ser nulo
    public bool IsActive { get; private set; } = true;

    private Tax() { }
    public Tax(Guid restaurantId, string code, string name, decimal? rate = null)
    {
        RestaurantId = restaurantId;
        if (string.IsNullOrWhiteSpace(code)) throw new ArgumentNullException(nameof(code));
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        Code = code; Name = name; Rate = rate;
    }
}


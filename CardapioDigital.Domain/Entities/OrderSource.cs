using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Domain.Entities;

public class OrderSource
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid RestaurantId { get; private set; }
    public string Code { get; private set; }   // QR, WAITER, ADMIN...
    public string Name { get; private set; }

    private OrderSource() { }
    public OrderSource(Guid restaurantId, string code, string name)
    {
        RestaurantId = restaurantId;
        if (string.IsNullOrWhiteSpace(code)) throw new ArgumentNullException(nameof(code));
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        Code = code; Name = name;
    }
}


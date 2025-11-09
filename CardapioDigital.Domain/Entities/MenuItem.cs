using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Domain.Entities;
public class MenuItem
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid RestaurantId { get; private set; }
    public Guid CategoryId { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public decimal Price { get; private set; }
    public string? PhotoUrl { get; private set; }
    public string? Tags { get; private set; }
    public bool IsActive { get; private set; } = true;

    private MenuItem() { }
    public MenuItem(Guid restaurantId, Guid categoryId, string name, decimal price,
                    string? description = null, string? photoUrl = null, string? tags = null)
    {
        RestaurantId = restaurantId; CategoryId = categoryId;
        Name = string.IsNullOrWhiteSpace(name) ? throw new ArgumentNullException(nameof(name)) : name;
        if (price < 0) throw new ArgumentOutOfRangeException(nameof(price));
        Price = price; Description = description; PhotoUrl = photoUrl; Tags = tags;
    }
    public void ChangePrice(decimal price) { if (price < 0) throw new ArgumentOutOfRangeException(); Price = price; }
    public void Activate() => IsActive = true;
    public void Deactivate() => IsActive = false;
}


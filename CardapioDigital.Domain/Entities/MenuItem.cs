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
    public bool IsActive { get; private set; } = true;

    private MenuItem() { }
    public MenuItem(Guid restaurantId, Guid categoryId, string name, decimal price, string? description = null)
    {
        RestaurantId = restaurantId;
        CategoryId = categoryId;
        Name = name; Price = price; Description = description;
    }
}


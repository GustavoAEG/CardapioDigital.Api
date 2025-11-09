using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CardapioDigital.Domain.Entities;
public class Category
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid RestaurantId { get; private set; }
    public string Name { get; private set; }
    public int DisplayOrder { get; private set; }
    public bool IsActive { get; private set; } = true;

    private Category() { }
    public Category(Guid restaurantId, string name, int displayOrder = 0)
    {
        RestaurantId = restaurantId;
        Name = name;
        DisplayOrder = displayOrder;
    }
}


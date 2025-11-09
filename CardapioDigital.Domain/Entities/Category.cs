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
    public int DisplayOrder { get; private set; } = 0;
    public bool IsActive { get; private set; } = true;

    private Category() { }
    public Category(Guid restaurantId, string name, int displayOrder = 0)
    {
        RestaurantId = restaurantId;
        Name = string.IsNullOrWhiteSpace(name) ? throw new ArgumentNullException(nameof(name)) : name;
        DisplayOrder = displayOrder;
    }
    public void Rename(string name) { /* validações… */ Name = name; }
    public void SetDisplayOrder(int order) => DisplayOrder = order;
    public void Activate() => IsActive = true;
    public void Deactivate() => IsActive = false;
}


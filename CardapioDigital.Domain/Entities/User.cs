using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Domain.Entities;

public class User
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid RestaurantId { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public byte[] PasswordHash { get; private set; }
    public bool IsActive { get; private set; } = true;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    private User() { }
    public User(Guid restaurantId, string name, string email, byte[] passwordHash)
    {
        RestaurantId = restaurantId;
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        if (string.IsNullOrWhiteSpace(email)) throw new ArgumentNullException(nameof(email));
        Name = name; Email = email; PasswordHash = passwordHash ?? throw new ArgumentNullException(nameof(passwordHash));
    }
}


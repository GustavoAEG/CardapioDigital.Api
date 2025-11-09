using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Domain.Entities;

public class RestaurantTheme
{
    public Guid RestaurantId { get; private set; }   // PK & FK
    public string? PrimaryColor { get; private set; }    // "#RRGGBB"
    public string? LogoUrl { get; private set; }
    public bool DarkMode { get; private set; } = false;

    private RestaurantTheme() { }
    public RestaurantTheme(Guid restaurantId, string? primaryColor = null, string? logoUrl = null, bool darkMode = false)
    {
        RestaurantId = restaurantId; PrimaryColor = primaryColor; LogoUrl = logoUrl; DarkMode = darkMode;
    }
}


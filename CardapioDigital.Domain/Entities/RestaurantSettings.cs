using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Domain.Entities;

public class RestaurantSettings
{
    [Key]
    public Guid RestaurantId { get; private set; }     // PK & FK
    public decimal? ServiceFeePercent { get; private set; }
    public bool AllowTips { get; private set; } = false;
    public string Locale { get; private set; } = "pt-BR";
    public string Currency { get; private set; } = "BRL";
    public bool PixEnabled { get; private set; }
    public bool PayPalEnabled { get; private set; }
    public bool CardEnabled { get; private set; }

    private RestaurantSettings() { }
    public RestaurantSettings(Guid restaurantId)
    {
        RestaurantId = restaurantId;
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Domain.Entities;

public enum CouponType : byte { Percent = 1, Fixed = 2 }

public class Coupon
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid RestaurantId { get; private set; }
    public string Code { get; private set; }
    public CouponType Type { get; private set; }
    public decimal Value { get; private set; }
    public DateTime? ValidFrom { get; private set; }
    public DateTime? ValidTo { get; private set; }
    public bool IsActive { get; private set; } = true;

    private Coupon() { }
    public Coupon(Guid restaurantId, string code, CouponType type, decimal value, DateTime? validFrom = null, DateTime? validTo = null)
    {
        RestaurantId = restaurantId;
        if (string.IsNullOrWhiteSpace(code)) throw new ArgumentNullException(nameof(code));
        if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
        Code = code; Type = type; Value = value; ValidFrom = validFrom; ValidTo = validTo;
    }
}


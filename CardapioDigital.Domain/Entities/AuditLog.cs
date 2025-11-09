using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Domain.Entities;

public class AuditLog
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid? OrderId { get; private set; }
    public Guid? PaymentId { get; private set; }
    public Guid? UserId { get; private set; }
    public Guid? RestaurantId { get; private set; }

    public string Action { get; private set; }
    public string Target { get; private set; }
    public string? DataJson { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    private AuditLog() { }
    public AuditLog(string action, string target, Guid? orderId = null, Guid? paymentId = null, Guid? userId = null, Guid? restaurantId = null, string? dataJson = null)
    {
        if (string.IsNullOrWhiteSpace(action)) throw new ArgumentNullException(nameof(action));
        if (string.IsNullOrWhiteSpace(target)) throw new ArgumentNullException(nameof(target));
        Action = action; Target = target;
        OrderId = orderId; PaymentId = paymentId; UserId = userId; RestaurantId = restaurantId; DataJson = dataJson;
    }
}


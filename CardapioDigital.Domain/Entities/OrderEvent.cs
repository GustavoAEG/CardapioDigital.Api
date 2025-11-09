using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Domain.Entities;

public class OrderEvent
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid OrderId { get; private set; }
    public Guid? ActorUserId { get; private set; }
    public string EventType { get; private set; }
    public string? DataJson { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    private OrderEvent() { }
    public OrderEvent(Guid orderId, string eventType, Guid? actorUserId = null, string? dataJson = null)
    {
        OrderId = orderId;
        if (string.IsNullOrWhiteSpace(eventType)) throw new ArgumentNullException(nameof(eventType));
        EventType = eventType; ActorUserId = actorUserId; DataJson = dataJson;
    }
}


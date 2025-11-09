using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Domain.Entities;

public class OutboxMessage
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string AggregateType { get; private set; }     // ex.: "Order"
    public string AggregateId { get; private set; }       // ex.: Order.Id
    public string EventType { get; private set; }         // ex.: "OrderCreated"
    public string PayloadJson { get; private set; }
    public DateTime OccurredAt { get; private set; } = DateTime.UtcNow;
    public DateTime? ProcessedAt { get; private set; }

    private OutboxMessage() { }
    public OutboxMessage(string aggregateType, string aggregateId, string eventType, string payloadJson)
    {
        if (string.IsNullOrWhiteSpace(aggregateType)) throw new ArgumentNullException(nameof(aggregateType));
        if (string.IsNullOrWhiteSpace(aggregateId)) throw new ArgumentNullException(nameof(aggregateId));
        if (string.IsNullOrWhiteSpace(eventType)) throw new ArgumentNullException(nameof(eventType));
        if (string.IsNullOrWhiteSpace(payloadJson)) throw new ArgumentNullException(nameof(payloadJson));
        AggregateType = aggregateType; AggregateId = aggregateId; EventType = eventType; PayloadJson = payloadJson;
    }

    public void MarkProcessed() => ProcessedAt = DateTime.UtcNow;
}


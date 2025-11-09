using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Domain.Entities;

public class IdempotencyKey
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid? OrderId { get; private set; }
    public Guid? PaymentId { get; private set; }
    public string Scope { get; private set; }     // ex.: "CreatePayment", "PlaceOrder"
    public string Key { get; private set; }       // valor idempotente do cliente/psp
    public DateTime FirstSeenAt { get; private set; } = DateTime.UtcNow;
    public DateTime? LastProcessedAt { get; private set; }
    public byte[]? ResponseHash { get; private set; }

    private IdempotencyKey() { }
    public IdempotencyKey(string scope, string key, Guid? orderId = null, Guid? paymentId = null)
    {
        if (string.IsNullOrWhiteSpace(scope)) throw new ArgumentNullException(nameof(scope));
        if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
        Scope = scope; Key = key; OrderId = orderId; PaymentId = paymentId;
    }

    public void TouchProcessed(byte[]? responseHash = null)
    {
        LastProcessedAt = DateTime.UtcNow; ResponseHash = responseHash;
    }
}


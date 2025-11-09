using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Domain.Entities;

public enum PaymentMethod : byte { Pix = 1, PayPal = 2, Card = 3, Table = 4 } // "Mesa" = pagamento manual/na mesa
public enum PaymentState : byte { Created = 0, Pending = 1, Authorized = 2, Captured = 3, Refunded = 4, Failed = 5, Canceled = 6 }

public class Payment
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid OrderId { get; private set; }
    public PaymentMethod Method { get; private set; }
    public string PSP { get; private set; }               // Provedor (ex.: PayPal)
    public string? ExternalId { get; private set; }
    public decimal Amount { get; private set; }
    public string Currency { get; private set; } = "BRL";
    public PaymentState Status { get; private set; } = PaymentState.Created;
    public DateTime? PaidAt { get; private set; }
    public string? RawPayloadJson { get; private set; }

    private Payment() { }
    public Payment(Guid orderId, PaymentMethod method, string psp, decimal amount, string currency = "BRL", string? externalId = null)
    {
        OrderId = orderId; Method = method; PSP = psp ?? throw new ArgumentNullException(nameof(psp));
        if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount));
        Amount = amount; Currency = currency; ExternalId = externalId;
    }
}


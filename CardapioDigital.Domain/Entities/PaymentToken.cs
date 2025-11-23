using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Domain.Entities
{
    public class PaymentToken
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid OrderId { get; private set; }
        public byte[] PaymentTokenHash { get; private set; } = Array.Empty<byte>();
        public DateTime ExpiresAtUtc { get; private set; }
        public DateTime? UsedAtUtc { get; private set; }
        public DateTime CreatedAtUtc { get; private set; } = DateTime.UtcNow;
        public string? CreatedBy { get; private set; }

        private PaymentToken() { }
        public PaymentToken(Guid orderId, byte[] hash, DateTime expiresAtUtc, string? createdBy = null)
        {
            OrderId = orderId;
            PaymentTokenHash = hash ?? throw new ArgumentNullException(nameof(hash));
            ExpiresAtUtc = expiresAtUtc;
            CreatedBy = createdBy;
        }

        public void MarkAsUsed() => UsedAtUtc = DateTime.UtcNow;
    }
}


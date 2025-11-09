using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Domain.Entities
{
    public enum OrderStatus : byte { Open = 0, InPreparation = 1, Ready = 2, Delivered = 3, Closed = 4, Canceled = 5 }
    public enum PaymentStatus : byte { None = 0, Pending = 1, PartiallyPaid = 2, Paid = 3, Refunded = 4, Failed = 5 }

    public class Order
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid RestaurantId { get; private set; }
        public Guid TableId { get; private set; }
        public Guid? ClientSessionId { get; private set; }
        public Guid? CreatedByUserId { get; private set; }
        public Guid? ClosedByUserId { get; private set; }
        public Guid? CancellationReasonId { get; private set; }
        public Guid? CouponId { get; private set; }
        public Guid? OrderSourceId { get; private set; }

        public OrderStatus Status { get; private set; } = OrderStatus.Open;
        public DateTime OpenedAt { get; private set; } = DateTime.UtcNow;
        public DateTime? ClosedAt { get; private set; }

        public decimal Subtotal { get; private set; } = 0;
        public decimal ServiceTax { get; private set; } = 0;
        public decimal Discount { get; private set; } = 0;
        public decimal Total { get; private set; } = 0;

        public PaymentStatus PaymentStatus { get; private set; } = PaymentStatus.None;
        public string? Notes { get; private set; }

        private Order() { }
        public Order(Guid restaurantId, Guid tableId, Guid? clientSessionId = null, Guid? orderSourceId = null, string? notes = null)
        {
            RestaurantId = restaurantId; TableId = tableId; ClientSessionId = clientSessionId; OrderSourceId = orderSourceId; Notes = notes;
        }

        // métodos de domínio (ex.: AddItem/Close/Cancel) ficam pra próxima etapa.
    }
}

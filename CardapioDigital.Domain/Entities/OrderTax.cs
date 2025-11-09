using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Domain.Entities;

public class OrderTax
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid OrderId { get; private set; }
    public Guid TaxId { get; private set; }

    public decimal BaseAmount { get; private set; }
    public decimal? RateApplied { get; private set; }
    public decimal TaxAmount { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    private OrderTax() { }
    public OrderTax(Guid orderId, Guid taxId, decimal baseAmount, decimal taxAmount, decimal? rateApplied = null)
    {
        OrderId = orderId; TaxId = taxId;
        if (baseAmount < 0) throw new ArgumentOutOfRangeException(nameof(baseAmount));
        if (taxAmount < 0) throw new ArgumentOutOfRangeException(nameof(taxAmount));
        BaseAmount = baseAmount; TaxAmount = taxAmount; RateApplied = rateApplied;
    }
}


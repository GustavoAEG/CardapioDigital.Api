using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Domain.Entities;

public class OrderItem
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid OrderId { get; private set; }
    public Guid MenuItemId { get; private set; }

    // snapshots
    public string NameSnapshot { get; private set; }
    public decimal UnitPrice { get; private set; }
    public int Qtd { get; private set; }
    public decimal LineTotal { get; private set; }
    public string? Notes { get; private set; }

    private OrderItem() { }
    public OrderItem(Guid orderId, Guid menuItemId, string nameSnapshot, decimal unitPrice, int qtd, string? notes = null)
    {
        OrderId = orderId; MenuItemId = menuItemId;
        if (string.IsNullOrWhiteSpace(nameSnapshot)) throw new ArgumentNullException(nameof(nameSnapshot));
        if (unitPrice < 0) throw new ArgumentOutOfRangeException(nameof(unitPrice));
        if (Qtd <= 0) throw new ArgumentOutOfRangeException(nameof(qtd));
        NameSnapshot = nameSnapshot; UnitPrice = unitPrice; Qtd = qtd; Notes = notes;
        LineTotal = UnitPrice * qtd;
    }
}


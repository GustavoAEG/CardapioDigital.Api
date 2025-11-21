using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Domain.Entities;

public class OrderNumber
{
    [Key]
    public Guid OrderId { get; private set; }   // PK & FK 1:1 com Order
    public string HumanNumber { get; private set; }
    public string? Series { get; private set; }
    public DateTime IssuedAt { get; private set; } = DateTime.UtcNow;

    private OrderNumber() { }
    public OrderNumber(Guid orderId, string humanNumber, string? series = null)
    {
        OrderId = orderId;
        if (string.IsNullOrWhiteSpace(humanNumber)) throw new ArgumentNullException(nameof(humanNumber));
        HumanNumber = humanNumber; Series = series;
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Domain.Entities;

public class PrintTicket
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid OrderId { get; private set; }
    public Guid? UserId { get; private set; }
    public string Target { get; private set; }           // COZINHA/BAR
    public DateTime PrintedAt { get; private set; } = DateTime.UtcNow;
    public string? Payload { get; private set; }

    private PrintTicket() { }
    public PrintTicket(Guid orderId, string target, Guid? userId = null, string? payload = null)
    {
        OrderId = orderId; UserId = userId;
        if (string.IsNullOrWhiteSpace(target)) throw new ArgumentNullException(nameof(target));
        Target = target; Payload = payload;
    }
}


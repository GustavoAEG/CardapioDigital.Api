using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Application.Commands
{
    public record CheckoutNowCommand(Guid OrderId, string InitiatedBySessionId) : IRequest<CheckoutNowResult>;

    public record CheckoutNowResult(Guid OrderId, string PaymentUrl, DateTime ExpiresAtUtc);
}

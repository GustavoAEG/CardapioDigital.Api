// CardapioDigital.Application/Handlers/CheckoutNowHandler.cs
using CardapioDigital.Application.Commands;
using CardapioDigital.Application.Services;
using CardapioDigital.Domain.Entities;
using CardapioDigital.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

public class CheckoutNowHandler : IRequestHandler<CheckoutNowCommand, CheckoutNowResult>
{
    private readonly IOrderRepository _orders;
    private readonly IPaymentTokenRepository _paymentTokens;
    private readonly ITokenService _tokenService;
    private readonly IConfiguration _cfg;

    public CheckoutNowHandler(
      IOrderRepository orders,
      IPaymentTokenRepository paymentTokens,
      ITokenService tokenService,
      IConfiguration cfg)
    {
        _orders = orders;
        _paymentTokens = paymentTokens;
        _tokenService = tokenService;
        _cfg = cfg;
    }

    public async Task<CheckoutNowResult> Handle(CheckoutNowCommand request, CancellationToken cancellationToken)
    {
        var order = await _orders.GetByIdAsync(request.OrderId, cancellationToken)
            ?? throw new KeyNotFoundException("Order not found.");

        // ... continua normalmente
    }
}

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
    private readonly ITableTokenService _tokenService;
    private readonly IConfiguration _cfg;

    public CheckoutNowHandler(
      IOrderRepository orders,
      IPaymentTokenRepository paymentTokens,
      ITableTokenService tokenService,
      IConfiguration cfg)
    {
        _orders = orders;
        _paymentTokens = paymentTokens;
        _tokenService = tokenService;
        _cfg = cfg;
    }

    public async Task<CheckoutNowResult> Handle(
        CheckoutNowCommand request,
        CancellationToken cancellationToken)
    {
        var order = await _orders.GetByIdAsync(request.OrderId, cancellationToken)
            ?? throw new KeyNotFoundException("Order not found.");

        var paymentUrl = "https://sandbox.psp.com/checkout/" + order.Id;
        var expiresAt = DateTime.UtcNow.AddMinutes(15);

        return new CheckoutNowResult(
            order.Id,
            paymentUrl,
            expiresAt
        );
    }
}

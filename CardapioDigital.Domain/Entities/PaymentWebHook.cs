using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Domain.Entities;

public class PaymentWebhook
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid? PaymentId { get; private set; }   // pode chegar antes do Payment existir
    public string PSP { get; private set; }
    public string? ExternalId { get; private set; }
    public string EventType { get; private set; }
    public string? HeadersJson { get; private set; }
    public string PayloadJson { get; private set; }
    public DateTime ReceivedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? ProcessedAt { get; private set; }
    public string? Error { get; private set; }
    public int Attempts { get; private set; } = 0;

    private PaymentWebhook() { }
    public PaymentWebhook(string psp, string eventType, string payloadJson, string? externalId = null, string? headersJson = null, Guid? paymentId = null)
    {
        if (string.IsNullOrWhiteSpace(psp)) throw new ArgumentNullException(nameof(psp));
        if (string.IsNullOrWhiteSpace(eventType)) throw new ArgumentNullException(nameof(eventType));
        if (string.IsNullOrWhiteSpace(payloadJson)) throw new ArgumentNullException(nameof(payloadJson));
        PSP = psp; EventType = eventType; PayloadJson = payloadJson;
        ExternalId = externalId; HeadersJson = headersJson; PaymentId = paymentId;
    }

    public void MarkProcessed() => ProcessedAt = DateTime.UtcNow;
    public void MarkError(string error) { Error = error; Attempts++; }
}


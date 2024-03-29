﻿using System.Text.Json.Serialization;
using IokaPayment.General.Enums;
using IokaPayment.General.Models;

namespace IokaPayment.Refunds.Responses;

public record OrderRefund
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("payment_id")]
    public required string PaymentId { get; init; }

    [JsonPropertyName("order_id")]
    public required string OrderId { get; init; }

    [JsonPropertyName("status")]
    public required RefundStatus Status { get; init; }

    [JsonPropertyName("created_at")]
    public required DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("error")]
    public ErrorResponse? Error { get; init; }

    [JsonPropertyName("acquirer")]
    public Acquirer? Acquirer { get; init; }
}
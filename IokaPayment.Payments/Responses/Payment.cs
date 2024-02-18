using System.Text.Json.Serialization;
using IokaPayment.General.Models;
using IokaPayment.General.Responses;

namespace IokaPayment.Payments.Responses;

public record Payment
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("shop_id")]
    public string ShopId { get; init; } = string.Empty;

    [JsonPropertyName("order_id")]
    public required string OrderId { get; init; }

    [JsonPropertyName("status")]
    public required string Status { get; init; }

    [JsonPropertyName("created_at")]
    public required string CreatedAt { get; init; }

    [JsonPropertyName("approved_amount")]
    public required int ApprovedAmount { get; init; }

    [JsonPropertyName("captured_amount")]
    public required int CapturedAmount { get; init; }

    [JsonPropertyName("refunded_amount")]
    public required int RefundedAmount { get; init; }

    [JsonPropertyName("processing_fee")]
    public required int ProcessingFee { get; init; }

    [JsonPropertyName("payer")]
    public required Payer Payer { get; init; }

    [JsonPropertyName("error")]
    public ErrorResponse? Error { get; init; }

    [JsonPropertyName("acquirer")]
    public Acquirer? Acquirer { get; init; }
}
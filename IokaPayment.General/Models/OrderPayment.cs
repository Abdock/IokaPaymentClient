using System.Text.Json.Serialization;
using IokaPayment.General.Enums;
using IokaPayment.General.Responses;

namespace IokaPayment.General.Models;

public record OrderPayment
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("order_id")]
    public required string OrderId { get; init; }

    [JsonPropertyName("status")]
    public required PaymentStatus Status { get; init; }

    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; init; }

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
    public required ErrorResponse Error { get; init; }

    [JsonPropertyName("acquirer")]
    public required Acquirer Acquirer { get; init; }

    [JsonPropertyName("action")]
    public required PaymentAction Action { get; init; }
}
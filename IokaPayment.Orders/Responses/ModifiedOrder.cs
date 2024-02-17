using System.Text.Json.Serialization;
using IokaPayment.General.Models;

namespace IokaPayment.Orders.Responses;

public record ModifiedOrder
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("order_id")]
    public required string OrderId { get; set; }

    [JsonPropertyName("status")]
    public required string Status { get; set; }

    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    [JsonPropertyName("approved_amount")]
    public required int ApprovedAmount { get; set; }

    [JsonPropertyName("captured_amount")]
    public required int CapturedAmount { get; set; }

    [JsonPropertyName("refunded_amount")]
    public required int RefundedAmount { get; set; }

    [JsonPropertyName("processing_fee")]
    public required int ProcessingFee { get; set; }

    [JsonPropertyName("payer")]
    public required Payer Payer { get; set; }

    [JsonPropertyName("error")]
    public required ErrorResponse Error { get; set; }

    [JsonPropertyName("acquirer")]
    public required Acquirer Acquirer { get; set; }

    [JsonPropertyName("action")]
    public required CaptureOrderAction Action { get; set; }
}
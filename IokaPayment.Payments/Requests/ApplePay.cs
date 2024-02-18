using System.Text.Json.Serialization;

namespace IokaPayment.Payments.Requests;

public record ApplePay
{
    [JsonPropertyName("paymentData")]
    public required dynamic PaymentData { get; init; }

    [JsonPropertyName("paymentMethod")]
    public required dynamic PaymentMethod { get; init; }

    [JsonPropertyName("transactionIdentifier")]
    public required string TransactionIdentifier { get; init; }
}
using System.Text.Json.Serialization;

namespace IokaPayment.Refunds.Responses;

public record RefundRule
{
    [JsonPropertyName("account_id")]
    public required string AccountId { get; init; }

    [JsonPropertyName("amount")]
    public required int Amount { get; init; }
}
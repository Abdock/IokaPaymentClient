using System.Text.Json.Serialization;
using IokaPayment.General.Enums;

namespace IokaPayment.Subscriptions.Requests;

public record CreateSubscription
{
    [JsonPropertyName("customer_id")]
    public required string CustomerId { get; init; }

    [JsonPropertyName("card_id")]
    public required string CardId { get; init; }

    [JsonPropertyName("amount")]
    public required int Amount { get; init; }

    [JsonPropertyName("currency")]
    public required Currency Currency { get; init; }

    [JsonPropertyName("description")]
    public string Description { get; init; } = string.Empty;

    [JsonPropertyName("extra_info")]
    public dynamic? ExtraInfo { get; init; }

    [JsonPropertyName("next_pay")]
    public required DateTimeOffset NextPay { get; init; }

    [JsonPropertyName("step")]
    public required int Step { get; init; }

    [JsonPropertyName("unit")]
    public required SubscriptionScheduleUnit Unit { get; init; }
}
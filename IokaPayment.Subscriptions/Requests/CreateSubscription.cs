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
    public Currency Currency { get; init; } = Currency.Kzt;

    [JsonPropertyName("description")]
    public string Description { get; init; } = string.Empty;

    [JsonPropertyName("extra_info")]
    public dynamic ExtraInfo { get; init; } = new object();

    [JsonPropertyName("next_pay")]
    public required DateTimeOffset NextPay { get; init; }

    [JsonPropertyName("step")]
    public int Step { get; init; } = 1;

    [JsonPropertyName("unit")]
    public required SubscriptionScheduleUnit Unit { get; init; }
}
using System.Text.Json.Serialization;
using IokaPayment.General.Enums;
using IokaPayment.General.Models;

namespace IokaPayment.Subscriptions.Responses;

public record Subscription
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("created_at")]
    public required DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("amount")]
    public required int Amount { get; init; }

    [JsonPropertyName("currency")]
    public required Currency Currency { get; init; }

    [JsonPropertyName("description")]
    public string Description { get; init; } = string.Empty;

    [JsonPropertyName("extra_info")]
    public dynamic? ExtraInfo { get; init; }

    [JsonPropertyName("payer")]
    public required Payer Payer { get; init; }

    [JsonPropertyName("schedule")]
    public required SubscriptionSchedule Schedule { get; init; }
}
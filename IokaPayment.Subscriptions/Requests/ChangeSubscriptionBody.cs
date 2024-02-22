using System.Text.Json.Serialization;
using IokaPayment.General.Enums;

namespace IokaPayment.Subscriptions.Requests;

public record ChangeSubscriptionBody
{
    [JsonPropertyName("status")]
    public required SubscriptionStatus Status { get; init; }
}
using System.Text.Json.Serialization;
using IokaPayment.General.Enums;

namespace IokaPayment.Subscriptions.Requests;

public record ChangeSubscriptionStatus
{
    [JsonIgnore]
    public required string SubscriptionId { get; init; }

    [JsonPropertyName("status")]
    public required SubscriptionStatus Status { get; init; }
}
using System.Text.Json.Serialization;
using IokaPayment.General.Enums;

namespace IokaPayment.Subscriptions.Responses;

public record SubscriptionSchedule
{
    [JsonPropertyName("status")]
    public required SubscriptionStatus Status { get; init; }

    [JsonPropertyName("next_pay")]
    public required DateTimeOffset NextPay { get; init; }

    [JsonPropertyName("step")]
    public required int Step { get; init; }

    [JsonPropertyName("unit")]
    public required SubscriptionScheduleUnit ScheduleUnit { get; init; }
}
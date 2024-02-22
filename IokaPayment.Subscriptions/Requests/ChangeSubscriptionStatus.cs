namespace IokaPayment.Subscriptions.Requests;

public record ChangeSubscriptionStatus
{
    public required string SubscriptionId { get; init; }

    public required ChangeSubscriptionBody Body { get; init; }
}
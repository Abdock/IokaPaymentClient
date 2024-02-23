namespace IokaPayment.Subscriptions.Requests;

public record UpdateSubscription
{
    public required string SubscriptionId { get; init; }
    public required CreateSubscription Body { get; init; }
}
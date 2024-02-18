namespace IokaPayment.Subscriptions;

public interface ISubscriptions
{
    Task<Response<PagedResponse<Subscription>>> GetSubscriptionsAsync(SubscriptionsPaginationQuery query, CancellationToken cancellationToken = default);
    Task<Response<Subscription>> CreateSubscriptionAsync(CreateSubscription query, CancellationToken cancellationToken = default);
    Task<Response<Subscription>> GetSubscriptionByIdAsync(string subscriptionId, CancellationToken cancellationToken = default);
    Task<Response<Subscription>> ChangeSubscriptionStatusAsync(ChangeSubscriptionStatus query, CancellationToken cancellationToken = default);
}
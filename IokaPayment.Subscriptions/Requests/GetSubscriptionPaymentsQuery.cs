using IokaPayment.General.Attributes;
using IokaPayment.General.Enums;
using IokaPayment.General.Requests;

namespace IokaPayment.Subscriptions.Requests;

public record GetSubscriptionPaymentsQuery : GetQuery
{
    public required string SubscriptionId { get; init; }

    [QueryParameterName("payment_status")]
    public PaymentStatus? PaymentStatus { get; init; }

    [QueryParameterName("offset")]
    public int? Offset { get; init; }

    [QueryParameterName("limit")]
    public int? Limit { get; init; }
}
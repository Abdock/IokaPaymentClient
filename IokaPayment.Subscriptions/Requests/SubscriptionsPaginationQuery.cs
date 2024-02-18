using IokaPayment.General.Attributes;
using IokaPayment.General.Enums;
using IokaPayment.General.Requests;

namespace IokaPayment.Subscriptions.Requests;

public record SubscriptionsPaginationQuery : PaginationQuery
{
    [QueryParameterName("subscription_id")]
    public string? SubscriptionId { get; init; }

    [QueryParameterName("pan_first6")]
    public string? PanFirst6 { get; init; }

    [QueryParameterName("pan_last4")]
    public string? PanLast4 { get; init; }

    [QueryParameterName("status")]
    public SubscriptionStatus? Status { get; init; }

    [QueryParameterName("next_pay")]
    public DateTimeOffset? NextPay { get; init; }

    [QueryParameterName("step")]
    public int Step { get; init; } = 1;

    [QueryParameterName("unit")]
    public SubscriptionScheduleUnit? ScheduleUnit { get; init; }
}
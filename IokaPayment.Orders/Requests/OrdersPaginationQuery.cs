using IokaPayment.General.Attributes;
using IokaPayment.General.Enums;
using IokaPayment.General.Requests;

namespace IokaPayment.Orders.Requests;

public record OrdersPaginationQuery : PaginationQuery
{
    [QueryParameterName("order_id")]
    public string? OrderId { get; init; }

    [QueryParameterName("external_id")]
    public string? ExternalId { get; init; }

    [QueryParameterName("order_status")]
    public OrderStatus? Status { get; init; }
}
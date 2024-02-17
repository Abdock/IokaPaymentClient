using System.ComponentModel.DataAnnotations;
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

    [QueryParameterName("fixed_amount")]
    [Range(0, int.MaxValue)]
    public int? FixedAmount { get; init; }

    [QueryParameterName("min_amount")]
    [Range(0, int.MaxValue)]
    public int? MinAmount { get; init; }

    [QueryParameterName("max_amount")]
    [Range(1, int.MaxValue)]
    public int? MaxAmount { get; init; }
}
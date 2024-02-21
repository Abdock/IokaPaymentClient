using IokaPayment.General.Attributes;
using IokaPayment.General.Enums;
using IokaPayment.General.Requests;

namespace IokaPayment.Customers.Requests;

public record CustomersPaginationQuery : PaginationQuery
{
    [QueryParameterName("customer_id")]
    public string? CustomerId { get; init; }

    [QueryParameterName("external_id")]
    public string? ExternalId { get; init; }

    [QueryParameterName("status")]
    public CustomerStatus? Status { get; init; }
}
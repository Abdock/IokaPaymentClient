using IokaPayment.General.Attributes;
using IokaPayment.General.Enums;
using IokaPayment.General.Requests;

namespace IokaPayment.Payments.Requests;

public record PaymentsPaginationQuery : PaginationQuery
{
    [QueryParameterName("payment_id")]
    public string? PaymentId { get; init; }

    public required string OrderId { get; init; }

    [QueryParameterName("external_id")]
    public string? ExternalId { get; init; }
    
    [QueryParameterName("pan_first6")]
    public string? PanFirst6 { get; init; }
    
    [QueryParameterName("pan_last4")]
    public string? PanLast4 { get; init; }
    
    [QueryParameterName("payer_email")]
    public string? PayerEmail { get; init; }
    
    [QueryParameterName("payer_phone")]
    public string? PayerPhone { get; init; }
    
    [QueryParameterName("customer_id")]
    public string? CustomerId { get; init; }
    
    [QueryParameterName("payment_status")]
    public PaymentStatus? PaymentStatus { get; init; }
    
    [QueryParameterName("payment_system")]
    public string? PaymentSystem { get; init; }
}
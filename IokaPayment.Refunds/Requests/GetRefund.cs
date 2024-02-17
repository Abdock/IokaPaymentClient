namespace IokaPayment.Refunds.Requests;

public record GetRefund
{
    public required string OrderId { get; init; }
    public required string RefundId { get; init; }
}
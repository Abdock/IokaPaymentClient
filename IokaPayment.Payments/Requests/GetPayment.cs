namespace IokaPayment.Payments.Requests;

public record GetPayment
{
    public required string OrderId { get; init; }
    public required string PaymentId { get; init; }
}
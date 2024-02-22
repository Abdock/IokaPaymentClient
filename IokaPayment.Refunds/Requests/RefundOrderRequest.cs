namespace IokaPayment.Refunds.Requests;

public record RefundOrderRequest
{
    public required string OrderId { get; init; }

    public required RefundBody Body { get; init; }
}
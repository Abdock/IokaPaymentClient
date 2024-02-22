namespace IokaPayment.Cards.Requests;

public record BindCardRequest
{
    public required string CustomerId { get; init; }
    public required CreateCardRequest Request { get; init; }
}
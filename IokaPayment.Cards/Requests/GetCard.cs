namespace IokaPayment.Cards.Requests;

public record GetCard
{
    public required string CardId { get; init; }
    public required string CustomerId { get; init; }
}
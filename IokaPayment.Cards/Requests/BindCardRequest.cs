namespace IokaPayment.Cards.Requests;

public record BindCardRequest
{
    public required string CustomerId { get; init; }
    public required string AccessToken { get; init; }
    public required CardBody Body { get; init; }
}
namespace IokaPayment.General.Responses;

public record ErrorResponse
{
    public required string Code { get; init; }
    public required string Message { get; init; }
}
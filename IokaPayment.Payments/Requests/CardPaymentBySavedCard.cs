namespace IokaPayment.Payments.Requests;

public record CardPaymentBySavedCard
{
    public required string OrderId { get; init; }

    public required SavedCardBody Body { get; init; }
}
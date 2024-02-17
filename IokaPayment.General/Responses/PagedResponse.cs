namespace IokaPayment.General.Responses;

public record PagedResponse<TData>
{
    public required IReadOnlyCollection<TData> Data { get; init; }
    public required int TotalCount { get; init; }
}
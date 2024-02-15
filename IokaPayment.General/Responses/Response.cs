namespace IokaPayment.General.Responses;

public class Response<TValue>
{
    public TValue? Result { get; }
    public ErrorResponse? Error { get; }
    public bool IsFailed => Error is not null;
    public bool IsSuccess => Result is not null;

    public Response(TValue result)
    {
        Result = result;
    }

    public Response(ErrorResponse error)
    {
        Error = error;
    }

    public static implicit operator Response<TValue>(TValue value) => new(value);
    public static implicit operator Response<TValue>(ErrorResponse error) => new(error);
}
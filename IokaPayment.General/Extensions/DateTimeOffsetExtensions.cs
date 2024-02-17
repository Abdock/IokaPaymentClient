namespace IokaPayment.General.Extensions;

public static class DateTimeOffsetExtensions
{
    public static bool IsUtcDateTime(this DateTimeOffset dateTimeOffset)
    {
        return dateTimeOffset.Offset == TimeSpan.Zero;
    }
}
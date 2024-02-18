namespace IokaPayment.General.Enums;

public enum PaymentStatus
{
    Pending,
    RequiresAction,
    Approved,
    Captured,
    Cancelled,
    Declined
}
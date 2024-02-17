namespace IokaPayment.General.Enums;

public enum CaptureMethod
{
    /// <summary>
    /// Автоматический т.е. одностадийный платеж
    /// </summary>
    Auto,
    /// <summary>
    /// Двухстадийный платеж, где первая стадия - авторизация платежа, вторая - подтверждение списания платежа.
    /// </summary>
    Manual
}
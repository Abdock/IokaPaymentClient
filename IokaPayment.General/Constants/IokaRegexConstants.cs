namespace IokaPayment.General.Constants;

public class IokaRegexConstants
{
    public const string PanRegex = @"^\d{12,19}$";
    public const string ExpRegex = @"^\d{2}/(\d{2})$";
    public const string CvcRegex = @"^\d{3,4}$";
    public const string PhoneRegex = @"^\+\d{4,15}$";
    public const string MccRegex = @"^\d{4}$";
}
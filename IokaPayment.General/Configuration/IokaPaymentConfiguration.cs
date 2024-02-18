using IokaPayment.General.Enums;

namespace IokaPayment.General.Configuration;

public record IokaPaymentConfiguration
{
    public string ApiKey { get; set; } = string.Empty;
    public IokaEnvironment Environment { get; set; } = IokaEnvironment.Stage;
}
using IokaPayment.General.Enums;

namespace IokaPayment.Client.Configurations;

public record IokaPaymentConfiguration
{
    public string ApiKey { get; set; } = string.Empty;
    public IokaEnvironment Environment { get; set; } = IokaEnvironment.Stage;
}
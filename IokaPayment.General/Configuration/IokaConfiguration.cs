using IokaPayment.General.Enums;

namespace IokaPayment.General.Configuration;

public record IokaConfiguration
{
    public required string ApiKey { get; init; }
    public required IokaEnvironment Environment { get; init; }
    public string Host => Environment == IokaEnvironment.Stage ? "https://stage-api.ioka.kz/v2" : "https://api.ioka.kz/v2";
}
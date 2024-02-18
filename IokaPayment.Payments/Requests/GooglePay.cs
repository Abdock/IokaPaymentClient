using System.Text.Json.Serialization;

namespace IokaPayment.Payments.Requests;

public record GooglePay
{
    [JsonPropertyName("protocolVersion")]
    public required string ProtocolVersion { get; init; }

    [JsonPropertyName("signature")]
    public required string Signature { get; init; }

    [JsonPropertyName("intermediateSigningKey")]
    public required dynamic IntermediateSigningKey { get; init; }

    [JsonPropertyName("signedMessage")]
    public dynamic? SignedMessage { get; init; }
}
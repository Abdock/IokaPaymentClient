using System.Text.Json.Serialization;

namespace IokaPayment.General.Models;

public record Resource
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("iban")]
    public required string Iban { get; init; }

    [JsonPropertyName("is_default")]
    public required bool IsDefault { get; init; }
}
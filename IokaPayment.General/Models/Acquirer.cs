using System.Text.Json.Serialization;

namespace IokaPayment.General.Models;

public record Acquirer
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("reference")]
    public string Reference { get; init; } = string.Empty;
}
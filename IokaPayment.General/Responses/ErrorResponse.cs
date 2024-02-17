using System.Text.Json.Serialization;

namespace IokaPayment.General.Responses;

public record ErrorResponse
{
    [JsonPropertyName("code")]
    public required string Code { get; init; }

    [JsonPropertyName("message")]
    public required string Message { get; init; }
}
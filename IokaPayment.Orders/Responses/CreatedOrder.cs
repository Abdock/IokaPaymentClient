using System.Text.Json.Serialization;

namespace IokaPayment.Orders.Responses;

public record CreatedOrder
{
    [JsonPropertyName("order")]
    public required Order Order { get; init; }

    [JsonPropertyName("order_access_token")]
    public required string AccessToken { get; init; }
}
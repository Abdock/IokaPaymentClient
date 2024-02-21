using System.Text.Json.Serialization;

namespace IokaPayment.Customers.Responses;

public record CreatedCustomer
{
    [JsonPropertyName("customer")]
    public required Customer Customer { get; init; }

    [JsonPropertyName("customer_access_token")]
    public required string AccessToken { get; init; }
}
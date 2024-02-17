using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IokaPayment.Orders.Requests;

public record UpdateOrderRequest
{
    [JsonIgnore]
    public required string OrderId { get; init; }

    [JsonPropertyName("amount")]
    [Range(100, int.MaxValue)]
    public required int Amount { get; init; }
}
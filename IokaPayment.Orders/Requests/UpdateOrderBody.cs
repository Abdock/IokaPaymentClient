using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IokaPayment.Orders.Requests;

public record UpdateOrderBody
{
    [JsonPropertyName("amount")]
    [Range(100, int.MaxValue)]
    public required int Amount { get; init; }
}
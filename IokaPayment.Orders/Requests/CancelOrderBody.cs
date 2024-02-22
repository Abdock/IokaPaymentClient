using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IokaPayment.Orders.Requests;

public record CancelOrderBody
{
    [JsonPropertyName("reason")]
    [MaxLength(255)]
    public string Reason { get; init; } = string.Empty;
}
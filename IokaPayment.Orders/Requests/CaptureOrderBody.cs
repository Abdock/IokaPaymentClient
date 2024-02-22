using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IokaPayment.Orders.Requests;

public record CaptureOrderBody
{
    [JsonPropertyName("amount")]
    [Range(100, int.MaxValue)]
    public required int Amount { get; init; }

    [JsonPropertyName("reason")]
    [MaxLength(255)]
    public string Reason { get; init; } = string.Empty;
}
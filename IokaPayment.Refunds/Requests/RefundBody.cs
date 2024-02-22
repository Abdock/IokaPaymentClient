using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using IokaPayment.General.Models;

namespace IokaPayment.Refunds.Requests;

public record RefundBody
{
    [JsonPropertyName("amount")]
    public required int Amount { get; init; }

    [JsonPropertyName("reason")]
    [MaxLength(255)]
    public string Reason { get; init; } = string.Empty;

    [JsonPropertyName("rules")]
    public IReadOnlyCollection<RefundRule> Rules { get; init; } = new List<RefundRule>();

    [JsonPropertyName("positions")]
    public IReadOnlyCollection<CheckPosition> Positions { get; init; } = new List<CheckPosition>();
}
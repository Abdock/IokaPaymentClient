using System.Text.Json.Serialization;
using IokaPayment.General.Models;

namespace IokaPayment.Refunds.Responses;

public record RefundedOrder
{
    [JsonPropertyName("amount")]
    public required int Amount { get; set; }

    [JsonPropertyName("reason")]
    public required string Reason { get; set; }

    [JsonPropertyName("rules")]
    public IReadOnlyCollection<RefundRule> Rules { get; init; } = new List<RefundRule>();

    [JsonPropertyName("positions")]
    public IReadOnlyCollection<CheckPosition> Positions { get; init; } = new List<CheckPosition>();
}
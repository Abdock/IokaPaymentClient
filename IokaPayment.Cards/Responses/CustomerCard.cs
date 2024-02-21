using System.Text.Json.Serialization;
using IokaPayment.General.Models;
using IokaPayment.General.Responses;

namespace IokaPayment.Cards.Responses;

public record CustomerCard
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("customer_id")]
    public required string CustomerId { get; init; }

    [JsonPropertyName("created_at")]
    public required DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("pan_masked")]
    public required string PanMasked { get; init; }

    [JsonPropertyName("expiry_date")]
    public required string ExpiryDate { get; init; }

    [JsonPropertyName("holder")]
    public string Holder { get; init; } = string.Empty;

    [JsonPropertyName("payment_system")]
    public string PaymentSystem { get; init; } = string.Empty;

    [JsonPropertyName("emitter")]
    public string Emitter { get; init; } = string.Empty;

    [JsonPropertyName("cvc_required")]
    public required bool CvcRequired { get; init; }

    [JsonPropertyName("error")]
    public ErrorResponse? Error { get; init; }

    [JsonPropertyName("action")]
    public PaymentAction? Action { get; init; }
}
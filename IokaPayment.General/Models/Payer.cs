using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using IokaPayment.General.Enums;

namespace IokaPayment.General.Models;

public record Payer
{
    [JsonPropertyName("type")]
    public required PayType Type { get; init; }

    [JsonPropertyName("pan_masked")]
    [RegularExpression(@"^\d{0,6}\*+\d{0,4}$")]
    public required string PanMasked { get; init; }

    [JsonPropertyName("expiry_date")]
    [RegularExpression(@"^\d{2}/(\d{2})$")]
    public required string ExpiryDate { get; init; }

    [JsonPropertyName("holder")]
    public required string Holder { get; init; }

    [JsonPropertyName("payment_system")]
    public required string PaymentSystem { get; init; }

    [JsonPropertyName("emitter")]
    public required string Emitter { get; init; }

    [JsonPropertyName("email")]
    public string Email { get; init; } = string.Empty;

    [JsonPropertyName("phone")]
    [RegularExpression(@"^\+\d{4,15}$")]
    public string Phone { get; init; } = string.Empty;

    [JsonPropertyName("customer_id")]
    public required string CustomerId { get; init; }

    [JsonPropertyName("card_id")]
    public required string CardId { get; init; }
}
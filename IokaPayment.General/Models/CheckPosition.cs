using System.Text.Json.Serialization;
using IokaPayment.General.Enums;

namespace IokaPayment.General.Models;

public record CheckPosition
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("amount")]
    public required int Amount { get; set; }

    [JsonPropertyName("count")]
    public required int Count { get; set; }

    [JsonPropertyName("section")]
    public required int Section { get; set; }

    [JsonPropertyName("tax_percent")]
    public required int TaxPercent { get; set; }

    [JsonPropertyName("tax_type")]
    public required TaxType TaxType { get; set; }

    [JsonPropertyName("tax_amount")]
    public required int TaxAmount { get; set; }

    [JsonPropertyName("unit_code")]
    public required int UnitCode { get; set; }
}
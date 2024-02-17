using System.Text.Json.Serialization;
using IokaPayment.General.Enums;

namespace IokaPayment.General.Models;

public record CheckPosition
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("amount")]
    public int Amount { get; set; }

    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("section")]
    public int Section { get; set; }

    [JsonPropertyName("tax_percent")]
    public int TaxPercent { get; set; }

    [JsonPropertyName("tax_type")]
    public TaxType TaxType { get; set; }

    [JsonPropertyName("tax_amount")]
    public int TaxAmount { get; set; }

    [JsonPropertyName("unit_code")]
    public int UnitCode { get; set; }
}
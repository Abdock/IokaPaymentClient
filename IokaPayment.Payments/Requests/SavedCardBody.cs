using System.Text.Json.Serialization;

namespace IokaPayment.Payments.Requests;

public record SavedCardBody
{
    [JsonPropertyName("card_id")]
    public required string CardId { get; init; }
    
    [JsonPropertyName("fingerprint")]
    public required string Fingerprint { get; init; }

    [JsonPropertyName("phone_check_date")]
    public required DateTimeOffset PhoneCheckDate { get; init; }
}
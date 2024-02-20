using System.Text.Json.Serialization;

namespace IokaPayment.Payments.Requests;

public record CardPaymentBySavedCard
{
    [JsonIgnore]
    public required string OrderId { get; init; }

    [JsonPropertyName("card_id")]
    public required string CardId { get; init; }
    
    [JsonPropertyName("fingerprint")]
    public required string Fingerprint { get; init; }

    [JsonPropertyName("phone_check_date")]
    public required DateTimeOffset PhoneCheckDate { get; init; }
}
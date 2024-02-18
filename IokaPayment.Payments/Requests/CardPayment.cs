using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using IokaPayment.General.Enums;

namespace IokaPayment.Payments.Requests;

public record CardPayment
{
    [JsonIgnore]
    public required string OrderId { get; init; }

    [JsonPropertyName("pan")]
    [RegularExpression(IokaRegexConstants.PanRegex, ErrorMessage = "PAN must be [12,19] digits")]
    public required string Pan { get; init; }

    [JsonPropertyName("exp")]
    [RegularExpression(IokaRegexConstants.ExpRegex, ErrorMessage = "EXP must be in MM/YY format")]
    public required string Exp { get; init; }

    [JsonPropertyName("cvc")]
    [RegularExpression(IokaRegexConstants.CvcRegex, ErrorMessage = "CVC must be 3 or 4 digits")]
    public required string Cvc { get; init; }

    [JsonPropertyName("holder")]
    public required string Holder { get; init; }

    [JsonPropertyName("save")]
    public required bool Save { get; init; }

    [JsonPropertyName("email")]
    public required string Email { get; init; }

    [JsonPropertyName("phone")]
    [RegularExpression(IokaRegexConstants.PhoneRegex, ErrorMessage = "Phone in incorrect format")]
    public required string Phone { get; init; }

    [JsonPropertyName("card_id")]
    public required string CardId { get; init; }

    [JsonPropertyName("fingerprint")]
    public required string Fingerprint { get; init; }

    [JsonPropertyName("phone_check_date")]
    public required DateTimeOffset PhoneCheckDate { get; init; }

    [JsonPropertyName("channel")]
    public required MasterPassChannel Channel { get; init; }
}
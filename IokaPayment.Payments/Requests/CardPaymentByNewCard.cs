using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using IokaPayment.General.Enums;

namespace IokaPayment.Payments.Requests;

public record CardPaymentByNewCard
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
    public string Holder { get; init; } = string.Empty;

    [JsonPropertyName("save")]
    public bool Save { get; init; } = false;

    [JsonPropertyName("email")]
    public string Email { get; init; } = string.Empty;

    [JsonPropertyName("phone")]
    [RegularExpression(IokaRegexConstants.PhoneRegex, ErrorMessage = "Phone in incorrect format")]
    public string Phone { get; init; } = string.Empty;

    [JsonPropertyName("channel")]
    public required MasterPassChannel Channel { get; init; }
}
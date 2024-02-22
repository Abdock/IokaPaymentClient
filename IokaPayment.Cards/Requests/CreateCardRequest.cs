using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using IokaPayment.General.Constants;

namespace IokaPayment.Cards.Requests;

public record CreateCardRequest
{
    [JsonPropertyName("pan")]
    [RegularExpression(IokaRegexConstants.PanRegex)]
    public required string Pan { get; init; }

    [JsonPropertyName("exp")]
    [RegularExpression(IokaRegexConstants.ExpRegex)]
    public required string Exp { get; init; }

    [JsonPropertyName("cvc")]
    [RegularExpression(IokaRegexConstants.CvcRegex)]
    public required string Cvc { get; init; }

    [JsonPropertyName("holder")]
    public string Holder { get; init; } = string.Empty;
}
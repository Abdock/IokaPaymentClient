using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using IokaPayment.General.Enums;

namespace IokaPayment.Orders.Requests;

public record CreateOrderRequest
{
    [JsonPropertyName("amount")]
    [Range(100, int.MaxValue)]
    public required int Amount { get; init; }

    [JsonPropertyName("currency")]
    public required Currency Currency { get; init; }

    [JsonPropertyName("capture_method")]
    public required CaptureMethod CaptureMethod { get; init; }

    [JsonPropertyName("external_id")]
    public required string ExternalId { get; init; }

    [JsonPropertyName("description")]
    public string Description { get; init; } = string.Empty;

    [JsonPropertyName("mcc")]
    [RegularExpression(IokaRegexConstants.MccRegex, ErrorMessage = "MCC must be 4 digits")]
    public required string Mcc { get; init; }

    [JsonPropertyName("extra_info")]
    public dynamic ExtraInfo { get; init; } = new object();

    [JsonPropertyName("attempts")]
    [Range(1, 50, ErrorMessage = "Attempts must be between 1 and 50")]
    public required int Attempts { get; init; }

    [JsonPropertyName("due_date")]
    public required DateTimeOffset DueDate { get; init; }

    [JsonPropertyName("customer_id")]
    public required string CustomerId { get; init; }

    [JsonPropertyName("card_id")]
    public required string CardId { get; init; }

    [JsonPropertyName("back_url")]
    [MinLength(1, ErrorMessage = "URL must be between 1 and 2083")]
    [MaxLength(2083, ErrorMessage = "URL must be between 1 and 2083")]
    public required string BackUrl { get; init; }

    [JsonPropertyName("success_url")]
    [MinLength(1, ErrorMessage = "URL must be between 1 and 2083")]
    [MaxLength(2083, ErrorMessage = "URL must be between 1 and 2083")]
    public required string SuccessUrl { get; init; }

    [JsonPropertyName("failure_url")]
    [MinLength(1, ErrorMessage = "URL must be between 1 and 2083")]
    [MaxLength(2083, ErrorMessage = "URL must be between 1 and 2083")]
    public required string FailureUrl { get; init; }

    [JsonPropertyName("template")]
    public string Template { get; init; } = string.Empty;
}
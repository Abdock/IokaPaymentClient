using System.Text.Json.Serialization;
using IokaPayment.General.Enums;

namespace IokaPayment.Orders.Responses;

public record ShortOrder
{
    [JsonPropertyName("created_at")]
    public required string CreatedAt { get; init; }

    [JsonPropertyName("shop_id")]
    public required string ShopId { get; init; }

    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("status")]
    public required OrderStatus Status { get; init; }

    [JsonPropertyName("amount")]
    public required int Amount { get; init; }

    [JsonPropertyName("currency")]
    public required Currency Currency { get; init; }

    [JsonPropertyName("capture_method")]
    public required CaptureMethod CaptureMethod { get; init; }

    [JsonPropertyName("external_id")]
    public required string ExternalId { get; init; }

    [JsonPropertyName("description")]
    public string Description { get; init; } = string.Empty;

    [JsonPropertyName("extra_info")]
    public dynamic ExtraInfo { get; init; } = new object();

    [JsonPropertyName("mcc")]
    public required string Mcc { get; init; }

    [JsonPropertyName("acquirer")]
    public required string Acquirer { get; init; }

    [JsonPropertyName("customer_id")]
    public required string CustomerId { get; init; }

    [JsonPropertyName("card_id")]
    public required string CardId { get; init; }

    [JsonPropertyName("attempts")]
    public required int Attempts { get; init; }

    [JsonPropertyName("due_date")]
    public required DateTimeOffset DueDate { get; init; }

    [JsonPropertyName("checkout_url")]
    public required Uri CheckoutUrl { get; init; }
}
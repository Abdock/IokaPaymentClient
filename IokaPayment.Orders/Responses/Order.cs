using System.Text.Json.Serialization;
using IokaPayment.General.Enums;

namespace IokaPayment.Orders.Responses;

public record Order
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("shop_id")]
    public required string ShopId { get; init; }

    [JsonPropertyName("status")]
    public required OrderStatus Status { get; init; }

    [JsonPropertyName("created_at")]
    public required DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("amount")]
    public required int Amount { get; init; }

    [JsonPropertyName("currency")]
    public required Currency Currency { get; init; }

    [JsonPropertyName("capture_method")]
    public required CaptureMethod CaptureMethod { get; init; }

    [JsonPropertyName("external_id")]
    public required string ExternalId { get; init; }

    [JsonPropertyName("description")]
    public required string Description { get; init; }

    [JsonPropertyName("extra_info")]
    public dynamic? ExtraInfo { get; init; }

    [JsonPropertyName("attempts")]
    public required int Attempts { get; init; }

    [JsonPropertyName("due_date")]
    public required DateTimeOffset DueDate { get; init; }

    [JsonPropertyName("customer_id")]
    public required string CustomerId { get; init; }

    [JsonPropertyName("card_id")]
    public required string CardId { get; init; }

    [JsonPropertyName("back_url")]
    public required Uri BackUrl { get; init; }

    [JsonPropertyName("success_url")]
    public required Uri SuccessUrl { get; init; }

    [JsonPropertyName("failure_url")]
    public required Uri FailureUrl { get; init; }

    [JsonPropertyName("template")]
    public required string Template { get; init; }

    [JsonPropertyName("checkout_url")]
    public required Uri CheckoutUrl { get; init; }

    [JsonPropertyName("access_token")]
    public required string AccessToken { get; init; }

    [JsonPropertyName("mcc")]
    public required string Mcc { get; init; }
}
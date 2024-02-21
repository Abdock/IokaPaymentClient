using System.Text.Json.Serialization;
using IokaPayment.General.Enums;
using IokaPayment.General.Models;

namespace IokaPayment.Customers.Responses;

public record Customer
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("created_at")]
    public required DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("status")]
    public required CustomerStatus Status { get; init; }

    [JsonPropertyName("external_id")]
    public string ExternalId { get; init; } = string.Empty;

    [JsonPropertyName("email")]
    public string Email { get; init; } = string.Empty;

    [JsonPropertyName("phone")]
    public string Phone { get; init; } = string.Empty;

    [JsonPropertyName("accounts")]
    public required IReadOnlyCollection<Account> Accounts { get; init; } = new List<Account>();

    [JsonPropertyName("checkout_url")]
    public required Uri CheckoutUrl { get; init; }

    [JsonPropertyName("access_token")]
    public required string AccessToken { get; init; }
}
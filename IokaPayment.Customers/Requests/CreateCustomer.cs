using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using IokaPayment.General.Enums;

namespace IokaPayment.Customers.Requests;

public record CreateCustomer
{
    [JsonPropertyName("external_id")]
    public required string ExternalId { get; init; }

    [JsonPropertyName("email")]
    [EmailAddress]
    public required string Email { get; init; }

    [JsonPropertyName("phone")]
    [Phone]
    public required string Phone { get; init; }

    [JsonPropertyName("fingerprint")]
    public required string Fingerprint { get; init; }

    [JsonPropertyName("phone_check_date")]
    public required DateTimeOffset PhoneCheckDate { get; init; }

    [JsonPropertyName("channel")]
    public required MasterPassChannel Channel { get; init; }
}
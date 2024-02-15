﻿using System.Text.Json.Serialization;
using IokaPayment.General.Enums;
using IokaPayment.General.Models;

namespace IokaPayment.Accounts.Responses;

public record Account
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("shop_id")]
    public required string ShopId { get; init; }

    [JsonPropertyName("customer_id")]
    public required string CustomerId { get; init; }

    [JsonPropertyName("status")]
    [JsonConverter(typeof(JsonStringEnumConverter<AccountStatus>))]
    public required AccountStatus Status { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("amount")]
    public required string Amount { get; init; }

    [JsonPropertyName("currency")]
    [JsonConverter(typeof(JsonStringEnumConverter<Currency>))]
    public required Currency Currency { get; init; }

    [JsonPropertyName("resources")]
    public required IReadOnlyCollection<Resource> Resources { get; init; }

    [JsonPropertyName("created_at")]
    public required DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("external_id")]
    public required string ExternalId { get; init; }
}
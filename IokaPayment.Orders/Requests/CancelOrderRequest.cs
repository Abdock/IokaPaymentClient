﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IokaPayment.Orders.Requests;

public record CancelOrderRequest
{
    public required string OrderId { get; init; }

    public required CancelOrderBody Body { get; init; }
}
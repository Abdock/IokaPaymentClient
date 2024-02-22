using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IokaPayment.Orders.Requests;

public record UpdateOrderRequest
{
    public required string OrderId { get; init; }

    public required UpdateOrderBody Body { get; init; }
}
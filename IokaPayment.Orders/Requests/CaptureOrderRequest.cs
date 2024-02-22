using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IokaPayment.Orders.Requests;

public record CaptureOrderRequest
{
    public required string OrderId { get; init; }

    public required CaptureOrderBody Body { get; init; }
}
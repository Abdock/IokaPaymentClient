using System.Text.Json.Serialization;
using IokaPayment.Payments.Enums;

namespace IokaPayment.Payments.Requests;

public record ToolPayment
{
    public required string OrderId { get; init; }
    public required ToolPaymentBody Body { get; init; }
}
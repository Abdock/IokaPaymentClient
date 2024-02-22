using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using IokaPayment.General.Enums;

namespace IokaPayment.Payments.Requests;

public record CardPaymentByNewCard
{
    public required string OrderId { get; init; }

    public required NewCardBody Body { get; init; }
}
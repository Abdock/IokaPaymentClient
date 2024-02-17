using System.Text.Json;
using System.Text.Json.Serialization;
using IokaPayment.General.Enums;

namespace IokaPayment.General.JsonConverters;

public class OrderStatusJsonConverter : JsonConverter<OrderStatus>
{
    public override OrderStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = string.Concat(reader.GetString()!.Split('_'));
        return Enum.Parse<OrderStatus>(value, ignoreCase: true);
    }

    public override void Write(Utf8JsonWriter writer, OrderStatus value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case OrderStatus.Expired:
                writer.WriteStringValue("EXPIRED");
                break;
            case OrderStatus.Paid:
                writer.WriteStringValue("PAID");
                break;
            case OrderStatus.Unpaid:
                writer.WriteStringValue("UNPAID");
                break;
            case OrderStatus.OnHold:
                writer.WriteStringValue("ON_HOLD");
                break;
            case OrderStatus.Pending:
                writer.WriteStringValue("PENDING");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value, null);
        }
    }
}
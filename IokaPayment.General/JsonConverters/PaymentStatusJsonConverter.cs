using System.Text.Json;
using System.Text.Json.Serialization;
using IokaPayment.General.Enums;

namespace IokaPayment.General.JsonConverters;

public class PaymentStatusJsonConverter : JsonConverter<PaymentStatus>
{
    public override PaymentStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = string.Concat(reader.GetString()!.Split('_'));
        return Enum.Parse<PaymentStatus>(value, ignoreCase: true);
    }

    public override void Write(Utf8JsonWriter writer, PaymentStatus value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case PaymentStatus.Pending:
                writer.WriteStringValue("PENDING");
                break;
            case PaymentStatus.RequiresAction:
                writer.WriteStringValue("REQUIRES_ACTION");
                break;
            case PaymentStatus.Approved:
                writer.WriteStringValue("APPROVED");
                break;
            case PaymentStatus.Captured:
                writer.WriteStringValue("CAPTURED");
                break;
            case PaymentStatus.Cancelled:
                writer.WriteStringValue("CANCELLED");
                break;
            case PaymentStatus.Declined:
                writer.WriteStringValue("DECLINED");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value, null);
        }
    }
}
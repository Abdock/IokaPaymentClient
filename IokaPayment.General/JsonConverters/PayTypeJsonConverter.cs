using System.Text.Json;
using System.Text.Json.Serialization;
using IokaPayment.General.Enums;

namespace IokaPayment.General.JsonConverters;

public class PayTypeJsonConverter : JsonConverter<PayType>
{
    public override PayType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = string.Concat(reader.GetString()!.Split('_'));
        return Enum.Parse<PayType>(value, ignoreCase: true);
    }

    public override void Write(Utf8JsonWriter writer, PayType value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case PayType.Binding:
                writer.WriteStringValue("BINDING");
                break;
            case PayType.Card:
                writer.WriteStringValue("CARD");
                break;
            case PayType.CardNoCvc:
                writer.WriteStringValue("CARD_NO_CVC");
                break;
            case PayType.CardWithBinding:
                writer.WriteStringValue("CARD_WITH_BINDING");
                break;
            case PayType.ApplePay:
                writer.WriteStringValue("APPLE_PAY");
                break;
            case PayType.GooglePay:
                writer.WriteStringValue("GOOGLE_PAY");
                break;
            case PayType.MasterPass:
                writer.WriteStringValue("MASTERPASS");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value, null);
        }
    }
}
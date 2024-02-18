using System.Text.Json;
using System.Text.Json.Serialization;
using IokaPayment.General.Enums;

namespace IokaPayment.General.JsonConverters;

public class SubscriptionStatusJsonConverter : JsonConverter<SubscriptionStatus>
{
    public override SubscriptionStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return Enum.Parse<SubscriptionStatus>(reader.GetString()!, ignoreCase: true);
    }

    public override void Write(Utf8JsonWriter writer, SubscriptionStatus value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString().ToUpperInvariant());
    }
}
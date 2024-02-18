using System.Text.Json;
using System.Text.Json.Serialization;
using IokaPayment.General.Enums;

namespace IokaPayment.General.JsonConverters;

public class ScheduleUnitJsonConverter : JsonConverter<SubscriptionScheduleUnit>
{
    public override SubscriptionScheduleUnit Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return Enum.Parse<SubscriptionScheduleUnit>(reader.GetString()!, ignoreCase: true);
    }

    public override void Write(Utf8JsonWriter writer, SubscriptionScheduleUnit value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString().ToUpperInvariant());
    }
}
using System.Text.Json;
using System.Text.Json.Serialization;
using IokaPayment.General.Enums;

namespace IokaPayment.General.JsonConverters;

public class RefundStatusJsonConverter : JsonConverter<RefundStatus>
{
    public override RefundStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString()!;
        return Enum.Parse<RefundStatus>(value, ignoreCase: true);
    }

    public override void Write(Utf8JsonWriter writer, RefundStatus value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString().ToUpperInvariant());
    }
}
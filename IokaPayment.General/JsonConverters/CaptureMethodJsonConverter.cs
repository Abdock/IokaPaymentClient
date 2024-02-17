using System.Text.Json;
using System.Text.Json.Serialization;
using IokaPayment.General.Enums;

namespace IokaPayment.General.JsonConverters;

public class CaptureMethodJsonConverter : JsonConverter<CaptureMethod>
{
    public override CaptureMethod Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString()!;
        return Enum.Parse<CaptureMethod>(value, ignoreCase: true);
    }

    public override void Write(Utf8JsonWriter writer, CaptureMethod value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString().ToUpperInvariant());
    }
}
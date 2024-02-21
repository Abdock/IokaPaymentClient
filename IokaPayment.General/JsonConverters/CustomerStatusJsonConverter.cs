using System.Text.Json;
using System.Text.Json.Serialization;
using IokaPayment.General.Enums;

namespace IokaPayment.General.JsonConverters;

public class CustomerStatusJsonConverter : JsonConverter<CustomerStatus>
{
    public override CustomerStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString()!;
        return Enum.Parse<CustomerStatus>(value, ignoreCase: true);
    }

    public override void Write(Utf8JsonWriter writer, CustomerStatus value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString().ToUpperInvariant());
    }
}
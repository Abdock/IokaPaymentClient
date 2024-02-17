using System.Text.Json;
using System.Text.Json.Serialization;
using IokaPayment.General.Enums;

namespace IokaPayment.General.JsonConverters;

public class CurrencyJsonConverter : JsonConverter<Currency>
{
    public override Currency Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var currency = reader.GetString()!;
        return Enum.Parse<Currency>(currency, ignoreCase: true);
    }

    public override void Write(Utf8JsonWriter writer, Currency value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString().ToUpperInvariant());
    }
}
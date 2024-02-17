using System.Text.Json;
using System.Text.Json.Serialization;
using IokaPayment.General.Enums;

namespace IokaPayment.General.JsonConverters;

public class TaxTypeJsonConverter : JsonConverter<TaxType>
{
    public override TaxType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetInt32();
        return value switch
        {
            0 => TaxType.WithoutVat,
            100 => TaxType.WithVat,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
        };
    }

    public override void Write(Utf8JsonWriter writer, TaxType value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue((int)value);
    }
}
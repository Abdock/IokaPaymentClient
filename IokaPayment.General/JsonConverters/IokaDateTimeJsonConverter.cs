using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using IokaPayment.General.Constants;

namespace IokaPayment.General.JsonConverters;

public class IokaDateTimeJsonConverter : JsonConverter<DateTimeOffset>
{
    public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (DateTimeOffset.TryParseExact(reader.GetString(), FormatConstants.DateTimeFormat, null, DateTimeStyles.None, out var datetime))
        {
            return datetime;
        }
        
        throw new ArgumentException("Date format is invalid format, it should be in RFC3339 format");
    }

    public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(FormatConstants.DateTimeFormat));
    }
}
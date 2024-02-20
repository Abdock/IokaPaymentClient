using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using IokaPayment.General.Constants;
using IokaPayment.General.Extensions;

namespace IokaPayment.General.JsonConverters;

public class IokaDateTimeJsonConverter : JsonConverter<DateTimeOffset>
{
    public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var date = reader.GetString()!;
        const string validDateTimeFormat = @"yyyy\-MM\-dd\THH\:mm\:ss.SSSSSS";
        if (!DateTimeOffset.TryParseExact(date, validDateTimeFormat, null, DateTimeStyles.None, out var datetime) && !DateTimeOffset.TryParse(date, out datetime))
            throw new ArgumentException("Date format is invalid format, it should be in RFC3339 format");

        return datetime;
    }

    public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
    {
        if (!value.IsUtcDateTime())
            throw new ArgumentException("The date time must be in UTC+0 format.");

        writer.WriteStringValue(value.UtcDateTime.ToString(FormatConstants.DateTimeFormat).TrimEnd('Z'));
    }
}
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using IokaPayment.General.Constants;

namespace IokaPayment.General.JsonConverters;

public class IokaDateTimeJsonConverter : JsonConverter<DateTimeOffset>
{
    public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var date = reader.GetString()!;
        const string validDateTimeFormat = @"yyyy\-MM\-dd\THH\:mm\:ss.SSSSSS";
        if (!DateTimeOffset.TryParseExact(date, validDateTimeFormat, null, DateTimeStyles.None, out var datetime) && !DateTimeOffset.TryParse(date, out datetime))
            throw new ArgumentException("Date format is invalid format, it should be in RFC3339 format");

        // Ioka returns datetime in UTC, so we need to recreate a new DateTimeOffset with the correct offset, because TryParseExact mark it as local time
        return new DateTimeOffset(datetime.DateTime, TimeSpan.Zero);
    }

    public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.UtcDateTime.ToString(FormatConstants.IokaDateTimeFormat).TrimEnd('Z'));
    }
}
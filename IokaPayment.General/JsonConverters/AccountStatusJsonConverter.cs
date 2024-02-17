using System.Text.Json;
using System.Text.Json.Serialization;
using IokaPayment.General.Enums;

namespace IokaPayment.General.JsonConverters;

public class AccountStatusJsonConverter : JsonConverter<AccountStatus>
{
    public override AccountStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString()!;
        return Enum.Parse<AccountStatus>(value, ignoreCase: true);
    }

    public override void Write(Utf8JsonWriter writer, AccountStatus value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString().ToUpperInvariant());
    }
}
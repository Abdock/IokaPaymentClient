using System.Text.Json;
using System.Text.Json.Serialization;
using IokaPayment.General.Enums;

namespace IokaPayment.General.JsonConverters;

public class MasterPassChannelJsonConverter : JsonConverter<MasterPassChannel>
{
    public override MasterPassChannel Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = string.Concat(reader.GetString()!.Split(' '));
        return Enum.Parse<MasterPassChannel>(value, ignoreCase: true);
    }

    public override void Write(Utf8JsonWriter writer, MasterPassChannel value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case MasterPassChannel.Web:
                writer.WriteStringValue("WEB");
                break;
            case MasterPassChannel.AppIos:
                writer.WriteStringValue("APP iOS");
                break;
            case MasterPassChannel.AppAndroid:
                writer.WriteStringValue("APP Android");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value, null);
        }
    }
}
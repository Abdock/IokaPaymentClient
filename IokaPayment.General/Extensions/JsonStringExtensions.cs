using System.Text.Json;

namespace IokaPayment.General.Extensions;

public static class JsonStringExtensions
{
    public static T DeserializeFromJson<T>(this string json)
    {
        var serializationResult = JsonSerializer.Deserialize<T>(json);
        if (serializationResult is null)
        {
            throw new JsonException($"Error deserializing {typeof(T).Name} from JSON: {json}");
        }

        return serializationResult;
    }
}
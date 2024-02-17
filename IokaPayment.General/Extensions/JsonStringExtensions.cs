using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace IokaPayment.General.Extensions;

public static class JsonStringExtensions
{
    private static readonly JsonSerializerOptions SerializationOptions;

    static JsonStringExtensions()
    {
        SerializationOptions = new JsonSerializerOptions(JsonSerializerOptions.Default);
        // Add the JSON converters to serialization options, because some enums should be convert manually.
        var converters = Assembly
            .GetExecutingAssembly().DefinedTypes
            .Where(IsCouldBeInstantiateByJsonConverter)
            .Select(Activator.CreateInstance)
            .Cast<JsonConverter>();
        foreach (var converter in converters)
        {
            SerializationOptions.Converters.Add(converter);
        }
    }

    private static bool IsCouldBeInstantiateByJsonConverter(TypeInfo type)
    {
        return type.IsAssignableTo(typeof(JsonConverter)) && type is { IsInterface: false, IsAbstract: false };
    }

    public static T DeserializeFromJson<T>(this string json)
    {
        var serializationResult = JsonSerializer.Deserialize<T>(json, SerializationOptions);
        if (serializationResult is null)
        {
            throw new JsonException($"Error deserializing {typeof(T).Name} from JSON: {json}");
        }

        return serializationResult;
    }
}
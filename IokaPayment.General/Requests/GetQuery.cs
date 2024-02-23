using System.Reflection;
using System.Text.Json;
using IokaPayment.General.Attributes;
using IokaPayment.General.Extensions;

namespace IokaPayment.General.Requests;

public abstract record GetQuery
{
    public virtual string ToQueryString(bool beginQuery = false)
    {
        var properties = GetType().GetProperties();
        var query = properties.Aggregate("", (current, property) =>
        {
            var value = property.GetValue(this);
            if (value is null)
            {
                return current;
            }

            var title = property.GetCustomAttribute<QueryParameterNameAttribute>()?.Title;
            if (title is null)
            {
                return current;
            }

            var stringValue = JsonSerializer.Serialize(value, JsonStringExtensions.SerializationOptions);

            return $"{current}{title.ToLowerInvariant()}={stringValue.Trim('"')}&";
        }).TrimEnd('&');
        return beginQuery ? $"?{query}" : query;
    }
}
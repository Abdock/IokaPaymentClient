using System.Reflection;
using IokaPayment.General.Attributes;
using IokaPayment.General.Constants;
using IokaPayment.General.Enums;

namespace IokaPayment.General.Requests;

public abstract record PaginationQuery
{
    [QueryParameterName("page")]
    public virtual required int Page { get; init; } = 1;

    [QueryParameterName("limit")]
    public virtual required int Limit { get; init; } = 10;

    [QueryParameterName("to_dt")]
    public virtual DateTimeOffset? ToDate { get; init; }

    [QueryParameterName("from_dt")]
    public virtual DateTimeOffset? FromDate { get; init; }

    [QueryParameterName("date_category")]
    public virtual DateCategory? DateCategory { get; init; }

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

            var name = property.GetCustomAttribute<QueryParameterNameAttribute>()?.Name ?? property.Name;
            var stringValue = value.ToString();
            if (value is DateTimeOffset date)
            {
                stringValue = date.ToString(FormatConstants.DateTimeFormat);
            }

            return $"{current}{name.ToLowerInvariant()}={stringValue}&";
        }).TrimEnd('&');
        return beginQuery ? $"?{query}" : query;
    }
}
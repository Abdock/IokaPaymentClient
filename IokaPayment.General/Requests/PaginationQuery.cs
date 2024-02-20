using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.Json;
using IokaPayment.General.Attributes;
using IokaPayment.General.Constants;
using IokaPayment.General.Enums;
using IokaPayment.General.Extensions;

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

    [QueryParameterName("amount_category")]
    public AmountCategory? AmountCategory { get; init; }

    [QueryParameterName("date_category")]
    public virtual DateCategory? DateCategory { get; init; }

    [QueryParameterName("fixed_amount")]
    [Range(0, int.MaxValue)]
    public int? FixedAmount { get; init; }

    [QueryParameterName("min_amount")]
    [Range(0, int.MaxValue)]
    public int? MinAmount { get; init; }

    [QueryParameterName("max_amount")]
    [Range(1, int.MaxValue)]
    public int? MaxAmount { get; init; }


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
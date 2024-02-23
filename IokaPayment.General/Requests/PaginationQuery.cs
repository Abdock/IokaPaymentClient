using System.ComponentModel.DataAnnotations;
using IokaPayment.General.Attributes;
using IokaPayment.General.Enums;

namespace IokaPayment.General.Requests;

public abstract record PaginationQuery : GetQuery
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
}
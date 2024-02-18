namespace IokaPayment.General.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class QueryParameterNameAttribute : Attribute
{
    public string Title { get; }

    public QueryParameterNameAttribute(string title) => Title = title;
}
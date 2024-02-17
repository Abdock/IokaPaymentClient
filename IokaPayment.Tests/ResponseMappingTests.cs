using IokaPayment.Accounts.Responses;
using IokaPayment.General.Extensions;
using IokaPayment.Orders.Requests;

namespace IokaPayment.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void AccountMapFromJson()
    {
        const string json = """
                            {
                              "id": "string",
                              "shop_id": "string",
                              "customer_id": "string",
                              "status": "PENDING",
                              "name": "string",
                              "amount": "string",
                              "currency": "KZT",
                              "resources": [
                                {
                                  "id": "string",
                                  "iban": "string",
                                  "is_default": true
                                }
                              ],
                              "created_at": "2019-08-24T14:15:22Z",
                              "external_id": "string"
                            }
                            """;
        AccountResponse? account = default;
        Assert.DoesNotThrow(() =>
        {
            account = json.DeserializeFromJson<AccountResponse>();
        });
        Assert.That(account, Is.Not.Null);
    }

    [Test]
    public void CreateQueryStringToGetOrders_Used2Arguments_ShouldReturnCorrectQueryString()
    {
        var query = new OrdersPaginationQuery
        {
            Page = 1,
            Limit = 10
        };
        Assert.That(query.ToQueryString(), Is.EqualTo("page=1&limit=10"));
    }

    [Test]
    public void CreateQueryStringToGetOrders_Used3ArgumentsWithDates_ShouldReturnCorrectQueryString()
    {
        const string fromDate = "2019-08-24T13:15:13Z";
        const string toDate = "2019-08-24T14:15:13Z";
        var query = new OrdersPaginationQuery
        {
            Page = 1,
            Limit = 10,
            ToDate = DateTimeOffset.Parse(toDate),
            FromDate = DateTimeOffset.Parse(fromDate)
        };
        Assert.That(query.ToQueryString(), Is.EqualTo($"page=1&limit=10&to_dt={toDate}&from_dt={fromDate}"));
    }
}
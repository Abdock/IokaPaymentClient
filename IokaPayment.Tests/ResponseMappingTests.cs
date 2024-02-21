using IokaPayment.General.Extensions;
using IokaPayment.General.Models;
using IokaPayment.Orders.Responses;
using IokaPayment.Refunds.Responses;

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
        Account? account = default;
        Assert.DoesNotThrow(() =>
        {
            account = json.DeserializeFromJson<Account>();
        });
        Assert.That(account, Is.Not.Null);
    }

    [Test]
    public void OrderMapFromJson()
    {
        const string json = """
                            {
                              "id": "string",
                              "shop_id": "string",
                              "status": "EXPIRED",
                              "created_at": "2019-08-24T14:15:22Z",
                              "amount": 0,
                              "currency": "KZT",
                              "capture_method": "AUTO",
                              "external_id": "string",
                              "description": "string",
                              "extra_info": {},
                              "attempts": 50,
                              "due_date": "2019-08-24T14:15:22Z",
                              "customer_id": "string",
                              "card_id": "string",
                              "back_url": "http://example.com",
                              "success_url": "http://example.com",
                              "failure_url": "http://example.com",
                              "template": "string",
                              "checkout_url": "http://example.com",
                              "access_token": "string",
                              "mcc": "string"
                            }
                            """;
        Order? order = default;
        Assert.DoesNotThrow(() =>
        {
            order = json.DeserializeFromJson<Order>();
        });
        Assert.That(order, Is.Not.Null);
    }

    [Test]
    public void RefundMapFromJson()
    {
        const string json = """
                            {
                              "id": "string",
                              "payment_id": "string",
                              "order_id": "string",
                              "status": "PENDING",
                              "created_at": "2019-08-24T14:15:22Z",
                              "error": {
                                "code": "string",
                                "message": "string"
                              },
                              "acquirer": {
                                "name": "string",
                                "reference": "string"
                              }
                            }
                            """;
        OrderRefund? refund = default;
        Assert.DoesNotThrow(() =>
        {
            refund = json.DeserializeFromJson<OrderRefund>();
        });
        Assert.That(refund, Is.Not.Null);
    }
}
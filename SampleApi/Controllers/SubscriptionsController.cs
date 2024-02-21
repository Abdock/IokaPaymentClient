using IokaPayment.Subscriptions;
using IokaPayment.Subscriptions.Requests;
using Microsoft.AspNetCore.Mvc;

namespace SampleApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubscriptionsController : ControllerBase
{
    private readonly ISubscriptions _subscriptions;

    public SubscriptionsController(ISubscriptions subscriptions)
    {
        _subscriptions = subscriptions;
    }

    [HttpGet]
    public async Task<IActionResult> GetSubscriptionsAsync()
    {
        var query = new SubscriptionsPaginationQuery
        {
            Page = 1,
            Limit = 10
        };
        var result = await _subscriptions.GetSubscriptionsAsync(query);
        return Ok(result.IsSuccess ? result.Result : result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSubscription([FromBody] CreateSubscription request)
    {
        var response = await _subscriptions.CreateSubscriptionAsync(request);
        return Ok(response);
    }
}
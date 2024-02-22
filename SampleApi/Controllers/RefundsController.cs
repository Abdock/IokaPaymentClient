using IokaPayment.Refunds;
using IokaPayment.Refunds.Requests;
using Microsoft.AspNetCore.Mvc;

namespace SampleApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RefundsController : ControllerBase
{
    private readonly IRefunds _refunds;

    public RefundsController(IRefunds refunds)
    {
        _refunds = refunds;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string orderId)
    {
        var refunds = await _refunds.GetOrderRefundsAsync(orderId);
        return Ok(refunds);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromQuery] string orderId, [FromBody] RefundBody request)
    {
        var query = new RefundOrderRequest
        {
            OrderId = orderId,
            Body = request
        };
        var response = await _refunds.RefundOrderAsync(query);
        return Ok(response.IsSuccess ? response.Result : response.Error);
    }
}
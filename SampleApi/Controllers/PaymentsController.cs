using IokaPayment.Payments;
using IokaPayment.Payments.Requests;
using Microsoft.AspNetCore.Mvc;

namespace SampleApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly IPayments _payments;

    public PaymentsController(IPayments payments)
    {
        _payments = payments;
    }

    [HttpGet]
    public async Task<IActionResult> GetPaymentsAsync([FromRoute] string orderId)
    {
        var request = new PaymentsPaginationQuery
        {
            OrderId = orderId,
            Page = 1,
            Limit = 10
        };
        var response = await _payments.GetPaymentsAsync(request);
        return Ok(response.IsSuccess ? response.Result : response.Error);
    }
}
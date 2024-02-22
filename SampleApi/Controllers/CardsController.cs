using IokaPayment.Cards;
using IokaPayment.Cards.Requests;
using Microsoft.AspNetCore.Mvc;

namespace SampleApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CardsController : ControllerBase
{
    private readonly ICards _cards;

    public CardsController(ICards cards)
    {
        _cards = cards;
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomerCards([FromQuery] string customerId)
    {
        var response = await _cards.GetCustomerCardsAsync(customerId);
        return Ok(response.IsSuccess ? response.Result : response.Error);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCustomerCard([FromQuery] string customerId, [FromQuery] string accessToken, [FromBody] CreateCardRequest request)
    {
        var query = new BindCardRequest
        {
            CustomerId = customerId,
            AccessToken = accessToken,
            Request = request
        };
        var response = await _cards.BindCardAsync(query);
        return Ok(response.IsSuccess ? response.Result : response.Error);
    }
}
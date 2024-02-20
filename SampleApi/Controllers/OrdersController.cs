using IokaPayment.General.Enums;
using IokaPayment.Orders;
using IokaPayment.Orders.Requests;
using Microsoft.AspNetCore.Mvc;

namespace SampleApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrders _orders;

    public OrdersController(IOrders orders)
    {
        _orders = orders;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] OrderData request)
    {
        var orderId = await _orders.CreateOrderAsync(request);
        return Ok(orderId.IsSuccess ? orderId.Result : orderId.Error);
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var request = new OrdersPaginationQuery
        {
            Page = 1,
            Limit = 10,
            Status = OrderStatus.Paid
        };
        var order = await _orders.GetOrdersAsync(request);
        return Ok(order.IsSuccess ? order.Result : order.Error);
    }
}
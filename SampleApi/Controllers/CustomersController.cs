using IokaPayment.Customers;
using IokaPayment.Customers.Requests;
using Microsoft.AspNetCore.Mvc;

namespace SampleApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomers _customers;

    public CustomersController(ICustomers customers)
    {
        _customers = customers;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new CustomersPaginationQuery
        {
            Page = 1,
            Limit = 10
        };
        var result = await _customers.GetCustomersAsync(query);
        return Ok(result.IsSuccess ? result.Result : result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateCustomer request)
    {
        var response = await _customers.CreateCustomerAsync(request);
        return Ok(response.IsSuccess ? response.Result!.Customer : response.Error);
    }
}
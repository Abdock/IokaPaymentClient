using System.Net;
using IokaPayment.Customers.Requests;
using IokaPayment.Customers.Responses;
using IokaPayment.General.Responses;

namespace IokaPayment.Customers;

public interface ICustomers
{
    Task<Response<PagedResponse<Customer>>> GetCustomersAsync(CustomersPaginationQuery query, CancellationToken cancellationToken = default);
    Task<Response<Customer>> GetCustomerByIdAsync(string customerId, CancellationToken cancellationToken = default);
    Task<Response<CreatedCustomer>> CreateCustomerAsync(CreateCustomer request, CancellationToken cancellationToken = default);
    Task<Response<HttpStatusCode>> DeleteCustomerAsync(string customerId, CancellationToken cancellationToken = default);
}
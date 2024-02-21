using System.Net;
using System.Net.Http.Json;
using IokaPayment.Customers.Requests;
using IokaPayment.Customers.Responses;
using IokaPayment.General.Configuration;
using IokaPayment.General.Constants;
using IokaPayment.General.Extensions;
using IokaPayment.General.Responses;
using Microsoft.Extensions.Logging;

namespace IokaPayment.Customers;

public class IokaCustomers : ICustomers
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<IokaCustomers> _logger;
    private readonly IokaConfiguration _configuration;

    public IokaCustomers(HttpClient httpClient, ILogger<IokaCustomers> logger, IokaConfiguration configuration)
    {
        _httpClient = httpClient;
        _logger = logger;
        _configuration = configuration;
    }

    public async Task<Response<PagedResponse<Customer>>> GetCustomersAsync(CustomersPaginationQuery query, CancellationToken cancellationToken = default)
    {
        var uri = $"{_configuration.Host}/customers?{query.ToQueryString()}";
        using var request = new HttpRequestMessage(HttpMethod.Get, uri);
        request.AddApiKey(_configuration.ApiKey);
        using var response = await _httpClient.SendAsync(request, cancellationToken);
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            var customers = json.DeserializeFromJson<List<Customer>>();
            var totalCount = int.Parse(response.Headers.GetValues(HttpHeaderConstants.TotalCount).First());
            return new PagedResponse<Customer>
            {
                Data = customers,
                TotalCount = totalCount
            };
        }
        
        var error = json.DeserializeFromJson<ErrorResponse>();
        _logger.LogError("Sent GET request to {Uri}, and received error {ErrorJson}", uri, json);
        return error;
    }

    public async Task<Response<Customer>> GetCustomerByIdAsync(string customerId, CancellationToken cancellationToken = default)
    {
        var uri = $"{_configuration.Host}/customers/{customerId}";
        using var request = new HttpRequestMessage(HttpMethod.Get, uri);
        request.AddApiKey(_configuration.ApiKey);
        using var response = await _httpClient.SendAsync(request, cancellationToken);
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return json.DeserializeFromJson<Customer>();
        }

        var error = json.DeserializeFromJson<ErrorResponse>();
        _logger.LogError("Sent GET request to {Uri}, and received error {ErrorJson}", uri, json);
        return error;
    }

    public async Task<Response<CreatedCustomer>> CreateCustomerAsync(CreateCustomer query, CancellationToken cancellationToken = default)
    {
        query.ThrowIfValidationFailed();
        var uri = $"{_configuration.Host}/customers";
        using var request = new HttpRequestMessage(HttpMethod.Post, uri);
        request.Content = JsonContent.Create(query, options: JsonStringExtensions.SerializationOptions);
        request.AddApiKey(_configuration.ApiKey);
        using var response = await _httpClient.SendAsync(request, cancellationToken);
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return json.DeserializeFromJson<CreatedCustomer>();
        }

        var error = json.DeserializeFromJson<ErrorResponse>();
        _logger.LogError("Sent POST request to {Uri}, and received error {ErrorJson}", uri, json);
        return error;
    }

    public async Task<Response<HttpStatusCode>> DeleteCustomerAsync(string customerId, CancellationToken cancellationToken = default)
    {
        var uri = $"{_configuration.Host}/customers/{customerId}";
        using var request = new HttpRequestMessage(HttpMethod.Delete, uri);
        request.AddApiKey(_configuration.ApiKey);
        using var response = await _httpClient.SendAsync(request, cancellationToken);
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return HttpStatusCode.NoContent;
        }

        var error = json.DeserializeFromJson<ErrorResponse>();
        _logger.LogError("Sent DELETE request to {Uri}, and received error {ErrorJson}", uri, json);
        return error;
    }
}
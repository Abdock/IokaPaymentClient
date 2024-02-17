using System.Net.Http.Json;
using Microsoft.Extensions.Logging;

namespace IokaPayment.Orders;

public class Orders : IOrders
{
    private readonly HttpClient _httpClient;
    private readonly IokaConfiguration _configuration;
    private readonly ILogger<Orders> _logger;

    public Orders(HttpClient httpClient, IokaConfiguration configuration, ILogger<Orders> logger)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<Response<CreatedOrder>> CreateOrderAsync(OrderData data, CancellationToken cancellationToken = default)
    {
        var uri = $"{_configuration.Host}/orders";
        using var request = new HttpRequestMessage(HttpMethod.Post, uri);
        request.Content = JsonContent.Create(data);
        request.AddApiKey(_configuration.ApiKey);
        using var response = await _httpClient.SendAsync(request, cancellationToken);
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return json.DeserializeFromJson<CreatedOrder>();
        }

        var error = json.DeserializeFromJson<ErrorResponse>();
        _logger.LogError("Sent POST request to {Uri}, and received error {ErrorJson}", uri, json);
        return error;
    }

    public async Task<Response<PagedResponse<Order>>> GetOrdersAsync(OrdersPaginationQuery query, CancellationToken cancellationToken = default)
    {
        var uri = $"{_configuration.Host}/orders?{query.ToQueryString()}";
        using var request = new HttpRequestMessage(HttpMethod.Get, uri);
        request.AddApiKey(_configuration.ApiKey);
        using var response = await _httpClient.SendAsync(request, cancellationToken);
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            var orders = json.DeserializeFromJson<List<Order>>();
            var totalCount = int.Parse(response.Headers.GetValues(HttpHeaderConstants.TotalCount).First());
            return new PagedResponse<Order>
            {
                Data = orders,
                TotalCount = totalCount
            };
        }

        var error = json.DeserializeFromJson<ErrorResponse>();
        _logger.LogError("Sent GET request to {Uri}, and received error {ErrorJson}", uri, json);
        return error;
    }

    public async Task<Response<Order>> GetOrderByIdAsync(string orderId, CancellationToken cancellationToken = default)
    {
        var uri = $"{_configuration.Host}/orders/{orderId}";
        using var request = new HttpRequestMessage(HttpMethod.Get, uri);
        request.AddApiKey(_configuration.ApiKey);
        using var response = await _httpClient.SendAsync(request, cancellationToken);
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return json.DeserializeFromJson<Order>();
        }

        var error = json.DeserializeFromJson<ErrorResponse>();
        _logger.LogError("Sent GET request to {Uri}, and received error {ErrorJson}", uri, json);
        return error;
    }

    public async Task<Response<Order>> UpdateOrderByIdAsync(UpdateOrderRequest updateRequest, CancellationToken cancellationToken = default)
    {
        var uri = $"{_configuration.Host}/orders/{updateRequest.OrderId}";
        using var request = new HttpRequestMessage(HttpMethod.Patch, uri);
        request.Content = JsonContent.Create(updateRequest);
        request.AddApiKey(_configuration.ApiKey);
        using var response = await _httpClient.SendAsync(request, cancellationToken);
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return json.DeserializeFromJson<Order>();
        }

        var error = json.DeserializeFromJson<ErrorResponse>();
        _logger.LogError("Sent PATCH request to {Uri}, and received error {ErrorJson}", uri, json);
        return error;
    }

    public async Task<Response<ModifiedOrder>> CaptureOrderAsync(CaptureOrderRequest captureRequest, CancellationToken cancellationToken = default)
    {
        var uri = $"{_configuration.Host}/orders/{captureRequest.OrderId}/capture";
        using var request = new HttpRequestMessage(HttpMethod.Post, uri);
        request.Content = JsonContent.Create(captureRequest);
        request.AddApiKey(_configuration.ApiKey);
        using var response = await _httpClient.SendAsync(request, cancellationToken);
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return json.DeserializeFromJson<ModifiedOrder>();
        }

        var error = json.DeserializeFromJson<ErrorResponse>();
        _logger.LogError("Sent POST request to {Uri}, and received error {ErrorJson}", uri, json);
        return error;
    }

    public async Task<Response<ModifiedOrder>> CancelOrderAsync(CancelOrderRequest cancelRequest, CancellationToken cancellationToken = default)
    {
        var uri = $"{_configuration.Host}/orders/{cancelRequest.OrderId}/cancel";
        using var request = new HttpRequestMessage(HttpMethod.Post, uri);
        request.Content = JsonContent.Create(cancelRequest);
        request.AddApiKey(_configuration.ApiKey);
        using var response = await _httpClient.SendAsync(request, cancellationToken);
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return json.DeserializeFromJson<ModifiedOrder>();
        }

        var error = json.DeserializeFromJson<ErrorResponse>();
        _logger.LogError("Sent POST request to {Uri}, and received error {ErrorJson}", uri, json);
        return error;
    }
}
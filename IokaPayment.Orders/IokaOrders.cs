using System.Net.Http.Json;
using IokaPayment.General.Models;
using IokaPayment.Orders.Requests;
using IokaPayment.Orders.Responses;
using Microsoft.Extensions.Logging;

namespace IokaPayment.Orders;

public class IokaOrders : IOrders
{
    private readonly HttpClient _httpClient;
    private readonly IokaConfiguration _configuration;
    private readonly ILogger<IokaOrders> _logger;

    public IokaOrders(HttpClient httpClient, IokaConfiguration configuration, ILogger<IokaOrders> logger)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<Response<CreatedOrder>> CreateOrderAsync(CreateOrderRequest query, CancellationToken cancellationToken = default)
    {
        query.ThrowIfValidationFailed();
        var uri = $"{_configuration.Host}/orders";
        using var request = new HttpRequestMessage(HttpMethod.Post, uri);
        request.Content = JsonContent.Create(query, options: JsonStringExtensions.SerializationOptions);
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

    public async Task<Response<PagedResponse<ShortOrder>>> GetOrdersAsync(OrdersPaginationQuery query, CancellationToken cancellationToken = default)
    {
        var uri = $"{_configuration.Host}/orders?{query.ToQueryString()}";
        using var request = new HttpRequestMessage(HttpMethod.Get, uri);
        request.AddApiKey(_configuration.ApiKey);
        using var response = await _httpClient.SendAsync(request, cancellationToken);
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            var orders = json.DeserializeFromJson<List<ShortOrder>>();
            var totalCount = int.Parse(response.Headers.GetValues(HttpHeaderConstants.TotalCount).First());
            return new PagedResponse<ShortOrder>
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
        updateRequest.ThrowIfValidationFailed();
        var uri = $"{_configuration.Host}/orders/{updateRequest.OrderId}";
        using var request = new HttpRequestMessage(HttpMethod.Patch, uri);
        request.Content = JsonContent.Create(updateRequest.Body, options: JsonStringExtensions.SerializationOptions);
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

    public async Task<Response<PaymentInformation>> CaptureOrderAsync(CaptureOrderRequest captureRequest, CancellationToken cancellationToken = default)
    {
        captureRequest.ThrowIfValidationFailed();
        var uri = $"{_configuration.Host}/orders/{captureRequest.OrderId}/capture";
        using var request = new HttpRequestMessage(HttpMethod.Post, uri);
        request.Content = JsonContent.Create(captureRequest.Body, options: JsonStringExtensions.SerializationOptions);
        request.AddApiKey(_configuration.ApiKey);
        using var response = await _httpClient.SendAsync(request, cancellationToken);
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return json.DeserializeFromJson<PaymentInformation>();
        }

        var error = json.DeserializeFromJson<ErrorResponse>();
        _logger.LogError("Sent POST request to {Uri}, and received error {ErrorJson}", uri, json);
        return error;
    }

    public async Task<Response<PaymentInformation>> CancelOrderAsync(CancelOrderRequest cancelRequest, CancellationToken cancellationToken = default)
    {
        cancelRequest.ThrowIfValidationFailed();
        var uri = $"{_configuration.Host}/orders/{cancelRequest.OrderId}/cancel";
        using var request = new HttpRequestMessage(HttpMethod.Post, uri);
        request.Content = JsonContent.Create(cancelRequest.Body, options: JsonStringExtensions.SerializationOptions);
        request.AddApiKey(_configuration.ApiKey);
        using var response = await _httpClient.SendAsync(request, cancellationToken);
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return json.DeserializeFromJson<PaymentInformation>();
        }

        var error = json.DeserializeFromJson<ErrorResponse>();
        _logger.LogError("Sent POST request to {Uri}, and received error {ErrorJson}", uri, json);
        return error;
    }
}
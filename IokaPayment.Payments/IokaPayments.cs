using System.Net.Http.Json;
using Microsoft.Extensions.Logging;

namespace IokaPayment.Payments;

public class IokaPayments : IPayments
{
    private readonly HttpClient _httpClient;
    private readonly IokaConfiguration _configuration;
    private readonly ILogger<IokaPayments> _logger;

    public IokaPayments(HttpClient httpClient, IokaConfiguration configuration, ILogger<IokaPayments> logger)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<Response<PagedResponse<Payment>>> GetPaymentsAsync(PaymentsPaginationQuery query, CancellationToken cancellationToken = default)
    {
        var uri = $"{_configuration.Host}/orders/{query.OrderId}/payments?{query.ToQueryString()}";
        using var request = new HttpRequestMessage(HttpMethod.Get, uri);
        request.AddApiKey(_configuration.ApiKey);
        using var response = await _httpClient.SendAsync(request, cancellationToken);
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            var payments = json.DeserializeFromJson<List<Payment>>();
            var totalCount = int.Parse(response.Headers.GetValues(HttpHeaderConstants.TotalCount).First());
            return new PagedResponse<Payment>
            {
                Data = payments,
                TotalCount = totalCount
            };
        }

        var error = json.DeserializeFromJson<ErrorResponse>();
        _logger.LogError("Sent GET request to {Uri}, and received error {ErrorJson}", uri, json);
        return error;
    }

    public async Task<Response<OrderPayment>> CreateCardPaymentAsync(CardPaymentByNewCard cardPayment, CancellationToken cancellationToken = default)
    {
        cardPayment.ThrowIfValidationFailed();
        var uri = $"{_configuration.Host}/orders/{cardPayment.OrderId}/payments/card";
        using var request = new HttpRequestMessage(HttpMethod.Post, uri);
        request.Content = JsonContent.Create(cardPayment, options: JsonStringExtensions.SerializationOptions);
        request.AddApiKey(_configuration.ApiKey);
        using var response = await _httpClient.SendAsync(request, cancellationToken);
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            var payment = json.DeserializeFromJson<OrderPayment>();
            return payment;
        }

        var error = json.DeserializeFromJson<ErrorResponse>();
        _logger.LogError("Sent POST request to {Uri}, and received error {ErrorJson}", uri, json);
        return error;
    }

    public async Task<Response<OrderPayment>> CreateCardPaymentAsync(CardPaymentBySavedCard cardPayment, CancellationToken cancellationToken = default)
    {
        cardPayment.ThrowIfValidationFailed();
        var uri = $"{_configuration.Host}/orders/{cardPayment.OrderId}/payments/card";
        using var request = new HttpRequestMessage(HttpMethod.Post, uri);
        request.Content = JsonContent.Create(cardPayment, options: JsonStringExtensions.SerializationOptions);
        request.AddApiKey(_configuration.ApiKey);
        using var response = await _httpClient.SendAsync(request, cancellationToken);
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            var payment = json.DeserializeFromJson<OrderPayment>();
            return payment;
        }

        var error = json.DeserializeFromJson<ErrorResponse>();
        _logger.LogError("Sent POST request to {Uri}, and received error {ErrorJson}", uri, json);
        return error;
    }

    public async Task<Response<OrderPayment>> CreateToolPaymentAsync(ToolPayment toolPayment, CancellationToken cancellationToken = default)
    {
        toolPayment.ThrowIfValidationFailed();
        var uri = $"{_configuration.Host}/orders/{toolPayment.OrderId}/payments/tool";
        using var request = new HttpRequestMessage(HttpMethod.Post, uri);
        request.Content = JsonContent.Create(toolPayment, options: JsonStringExtensions.SerializationOptions);
        request.AddApiKey(_configuration.ApiKey);
        using var response = await _httpClient.SendAsync(request, cancellationToken);
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            var payment = json.DeserializeFromJson<OrderPayment>();
            return payment;
        }

        var error = json.DeserializeFromJson<ErrorResponse>();
        _logger.LogError("Sent POST request to {Uri}, and received error {ErrorJson}", uri, json);
        return error;
    }

    public async Task<Response<OrderPayment>> GetPaymentByIdAsync(GetPayment query, CancellationToken cancellationToken = default)
    {
        var uri = $"{_configuration.Host}/orders/{query.OrderId}/payments/{query.PaymentId}";
        using var request = new HttpRequestMessage(HttpMethod.Get, uri);
        request.AddApiKey(_configuration.ApiKey);
        using var response = await _httpClient.SendAsync(request, cancellationToken);
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            var payment = json.DeserializeFromJson<OrderPayment>();
            return payment;
        }

        var error = json.DeserializeFromJson<ErrorResponse>();
        _logger.LogError("Sent GET request to {Uri}, and received error {ErrorJson}", uri, json);
        return error;
    }
}
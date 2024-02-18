using Microsoft.Extensions.Logging;

namespace IokaPayment.Refunds;

public class Refunds : IRefunds
{
    private readonly HttpClient _httpClient;
    private readonly IokaConfiguration _configuration;
    private readonly ILogger<Refunds> _logger;

    public Refunds(HttpClient httpClient, IokaConfiguration configuration, ILogger<Refunds> logger)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _logger = logger;
    }
    
    public async Task<Response<IReadOnlyCollection<OrderRefund>>> GetOrderRefundsAsync(string orderId, CancellationToken cancellationToken = default)
    {
        var uri = $"{_configuration.Host}/orders/{orderId}/refunds";
        using var request = new HttpRequestMessage(HttpMethod.Get, uri);
        request.AddApiKey(_configuration.ApiKey);
        using var response = await _httpClient.SendAsync(request, cancellationToken);
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return json.DeserializeFromJson<List<OrderRefund>>();
        }

        var error = json.DeserializeFromJson<ErrorResponse>();
        _logger.LogError("Sent GET request to {Uri}, and received error {ErrorJson}", uri, json);
        return error;
    }

    public async Task<Response<RefundedOrder>> RefundOrderAsync(string orderId, CancellationToken cancellationToken = default)
    {
        var uri = $"{_configuration.Host}/orders/{orderId}/refunds";
        using var request = new HttpRequestMessage(HttpMethod.Post, uri);
        request.AddApiKey(_configuration.ApiKey);
        using var response = await _httpClient.SendAsync(request, cancellationToken);
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return json.DeserializeFromJson<RefundedOrder>();
        }

        var error = json.DeserializeFromJson<ErrorResponse>();
        _logger.LogError("Sent POST request to {Uri}, and received error {ErrorJson}", uri, json);
        return error;
    }

    public async Task<Response<OrderRefund>> GetOrderRefundByIdAsync(GetRefund query, CancellationToken cancellationToken = default)
    {
        var uri = $"{_configuration.Host}/orders/{query.OrderId}/refunds/{query.RefundId}";
        using var request = new HttpRequestMessage(HttpMethod.Get, uri);
        request.AddApiKey(_configuration.ApiKey);
        using var response = await _httpClient.SendAsync(request, cancellationToken);
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return json.DeserializeFromJson<OrderRefund>();
        }

        var error = json.DeserializeFromJson<ErrorResponse>();
        _logger.LogError("Sent GET request to {Uri}, and received error {ErrorJson}", uri, json);
        return error;
    }
}
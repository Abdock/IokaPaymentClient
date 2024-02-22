using System.Net.Http.Json;
using Microsoft.Extensions.Logging;

namespace IokaPayment.Subscriptions;

public class IokaSubscriptions : ISubscriptions
{
    private readonly HttpClient _httpClient;
    private readonly IokaConfiguration _configuration;
    private readonly ILogger<IokaSubscriptions> _logger;

    public IokaSubscriptions(HttpClient httpClient, IokaConfiguration configuration, ILogger<IokaSubscriptions> logger)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<Response<PagedResponse<Subscription>>> GetSubscriptionsAsync(SubscriptionsPaginationQuery query, CancellationToken cancellationToken = default)
    {
        var uri = $"{_configuration.Host}/subscriptions";
        using var request = new HttpRequestMessage(HttpMethod.Get, uri);
        request.AddApiKey(_configuration.ApiKey);
        using var response = await _httpClient.SendAsync(request, cancellationToken);
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            var subscriptions = json.DeserializeFromJson<List<Subscription>>();
            var totalCount = int.Parse(response.Headers.GetValues(HttpHeaderConstants.TotalCount).First());
            return new PagedResponse<Subscription>
            {
                Data = subscriptions,
                TotalCount = totalCount
            };
        }
        
        var error = json.DeserializeFromJson<ErrorResponse>();
        _logger.LogError("Sent GET request to {Uri}, and received error {ErrorJson}", uri, json);
        return error;
    }

    public async Task<Response<Subscription>> CreateSubscriptionAsync(CreateSubscription query, CancellationToken cancellationToken = default)
    {
        query.ThrowIfValidationFailed();
        var uri = $"{_configuration.Host}/subscriptions";
        using var request = new HttpRequestMessage(HttpMethod.Post, uri);
        request.Content = JsonContent.Create(query, options: JsonStringExtensions.SerializationOptions);
        request.AddApiKey(_configuration.ApiKey);
        using var response = await _httpClient.SendAsync(request, cancellationToken);
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            var subscription = json.DeserializeFromJson<Subscription>();
            return subscription;
        }
        
        var error = json.DeserializeFromJson<ErrorResponse>();
        _logger.LogError("Sent POST request to {Uri}, and received error {ErrorJson}", uri, json);
        return error;
    }

    public async Task<Response<Subscription>> GetSubscriptionByIdAsync(string subscriptionId, CancellationToken cancellationToken = default)
    {
        var uri = $"{_configuration.Host}/subscriptions/{subscriptionId}";
        using var request = new HttpRequestMessage(HttpMethod.Get, uri);
        request.AddApiKey(_configuration.ApiKey);
        using var response = await _httpClient.SendAsync(request, cancellationToken);
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            var subscription = json.DeserializeFromJson<Subscription>();
            return subscription;
        }
        
        var error = json.DeserializeFromJson<ErrorResponse>();
        _logger.LogError("Sent GET request to {Uri}, and received error {ErrorJson}", uri, json);
        return error;
    }

    public async Task<Response<Subscription>> ChangeSubscriptionStatusAsync(ChangeSubscriptionStatus query, CancellationToken cancellationToken = default)
    {
        query.ThrowIfValidationFailed();
        var uri = $"{_configuration.Host}/subscriptions/{query.SubscriptionId}";
        using var request = new HttpRequestMessage(HttpMethod.Put, uri);
        request.Content = JsonContent.Create(query.Body, options: JsonStringExtensions.SerializationOptions);
        request.AddApiKey(_configuration.ApiKey);
        using var response = await _httpClient.SendAsync(request, cancellationToken);
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            var subscription = json.DeserializeFromJson<Subscription>();
            return subscription;
        }
        
        var error = json.DeserializeFromJson<ErrorResponse>();
        _logger.LogError("Sent PUT request to {Uri}, and received error {ErrorJson}", uri, json);
        return error;
    }
}
using System.Net;
using System.Net.Http.Json;
using IokaPayment.Cards.Requests;
using IokaPayment.Cards.Responses;
using IokaPayment.General.Configuration;
using IokaPayment.General.Extensions;
using IokaPayment.General.Responses;
using Microsoft.Extensions.Logging;

namespace IokaPayment.Cards;

public class IokaCards : ICards
{
    private readonly HttpClient _client;
    private readonly ILogger<IokaCards> _logger;
    private readonly IokaConfiguration _configuration;

    public IokaCards(HttpClient client, ILogger<IokaCards> logger, IokaConfiguration configuration)
    {
        _client = client;
        _logger = logger;
        _configuration = configuration;
    }

    public async Task<Response<IReadOnlyCollection<CustomerCard>>> GetCustomerCardsAsync(string customerId, CancellationToken cancellationToken = default)
    {
        var uri = $"{_configuration.Host}/customers/{customerId}/cards";
        using var request = new HttpRequestMessage(HttpMethod.Get, uri);
        request.AddApiKey(_configuration.ApiKey);
        using var response = await _client.SendAsync(request, cancellationToken);
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return json.DeserializeFromJson<List<CustomerCard>>();
        }

        var error = json.DeserializeFromJson<ErrorResponse>();
        return error;
    }

    public async Task<Response<CustomerCard>> GetCustomerCardByIdAsync(GetCard query, CancellationToken cancellationToken = default)
    {
        var uri = $"{_configuration.Host}/customers/{query.CustomerId}/cards/{query.CardId}";
        using var request = new HttpRequestMessage(HttpMethod.Get, uri);
        request.AddApiKey(_configuration.ApiKey);
        using var response = await _client.SendAsync(request, cancellationToken);
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return json.DeserializeFromJson<CustomerCard>();
        }

        var error = json.DeserializeFromJson<ErrorResponse>();
        return error;
    }

    public async Task<Response<CustomerCard>> BindCardAsync(BindCardRequest query, CancellationToken cancellationToken = default)
    {
        var uri = $"{_configuration.Host}/customers/{query.CustomerId}/bindings";
        using var request = new HttpRequestMessage(HttpMethod.Post, uri);
        request.Content = JsonContent.Create(query.Request, options: JsonStringExtensions.SerializationOptions);
        request.AddApiKey(_configuration.ApiKey).AddCustomerAccessToken(query.AccessToken);
        using var response = await _client.SendAsync(request, cancellationToken);
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return json.DeserializeFromJson<CustomerCard>();
        }

        var error = json.DeserializeFromJson<ErrorResponse>();
        return error;
    }

    public async Task<Response<HttpStatusCode>> DeleteCustomerCardByIdAsync(GetCard query, CancellationToken cancellationToken = default)
    {
        var uri = $"{_configuration.Host}/customers/{query.CustomerId}/cards/{query.CardId}";
        using var request = new HttpRequestMessage(HttpMethod.Delete, uri);
        request.AddApiKey(_configuration.ApiKey);
        using var response = await _client.SendAsync(request, cancellationToken);
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return HttpStatusCode.NoContent;
        }

        var error = json.DeserializeFromJson<ErrorResponse>();
        return error;
    }
}
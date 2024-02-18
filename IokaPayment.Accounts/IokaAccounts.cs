using IokaPayment.Accounts.Responses;
using IokaPayment.General.Configuration;
using IokaPayment.General.Extensions;
using IokaPayment.General.Responses;
using Microsoft.Extensions.Logging;

namespace IokaPayment.Accounts;

public class IokaAccounts : IAccounts
{
    private readonly HttpClient _httpClient;
    private readonly IokaConfiguration _configuration;
    private readonly ILogger<IokaAccounts> _logger;

    public IokaAccounts(HttpClient httpClient, IokaConfiguration configuration, ILogger<IokaAccounts> logger)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<Response<IReadOnlyCollection<AccountResponse>>> GetAccountsAsync(CancellationToken cancellationToken = default)
    {
        var uri = $"{_configuration.Host}/accounts";
        using var request = new HttpRequestMessage(HttpMethod.Get, uri);
        request.AddApiKey(_configuration.ApiKey);
        using var response = await _httpClient.SendAsync(request, cancellationToken);
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return json.DeserializeFromJson<List<AccountResponse>>();
        }

        var error = json.DeserializeFromJson<ErrorResponse>();
        _logger.LogError("Sent GET request to {Uri}, and received error {ErrorJson}", uri, json);
        return error;
    }

    public async Task<Response<AccountResponse>> GetAccountAsync(string accountId, CancellationToken cancellationToken = default)
    {
        var uri = $"{_configuration.Host}/accounts/{accountId}";
        using var request = new HttpRequestMessage(HttpMethod.Get, uri);
        request.AddApiKey(_configuration.ApiKey);
        using var response = await _httpClient.SendAsync(request, cancellationToken);
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return json.DeserializeFromJson<AccountResponse>();
        }

        var error = json.DeserializeFromJson<ErrorResponse>();
        _logger.LogError("Sent GET request to {Uri}, and received error {ErrorJson}", uri, json);
        return error;
    }
}
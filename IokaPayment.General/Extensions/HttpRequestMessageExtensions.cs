using IokaPayment.General.Constants;

namespace IokaPayment.General.Extensions;

public static class HttpRequestMessageExtensions
{
    public static HttpRequestMessage AddApiKey(this HttpRequestMessage request, string apiKey)
    {
        request.Headers.Add(HttpHeaderConstants.ApiKey, apiKey);
        return request;
    }
}
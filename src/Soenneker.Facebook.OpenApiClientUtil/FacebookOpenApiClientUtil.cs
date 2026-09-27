using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.Facebook.HttpClients.Abstract;
using Soenneker.Facebook.OpenApiClientUtil.Abstract;
using Soenneker.Facebook.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Facebook.OpenApiClientUtil;
public sealed class FacebookOpenApiClientUtil : IFacebookOpenApiClientUtil
{
    private readonly AsyncSingleton<FacebookOpenApiClient> _client;

    public FacebookOpenApiClientUtil(IFacebookOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<FacebookOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("Facebook:AccessToken");
            string authHeaderName = configuration["Facebook:AuthHeaderName"] ?? "Authorization";
            string authHeaderValueTemplate = configuration["Facebook:AuthHeaderValueTemplate"] ?? "Bearer {token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerName: authHeaderName, headerValue: authHeaderValue),
                httpClient: httpClient);
            string? baseUrl = configuration["Facebook:ClientBaseUrl"];
            if (!string.IsNullOrWhiteSpace(baseUrl)) requestAdapter.BaseUrl = baseUrl;

            return new FacebookOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<FacebookOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}

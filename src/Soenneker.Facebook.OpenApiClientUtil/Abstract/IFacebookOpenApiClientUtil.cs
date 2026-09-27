using Soenneker.Facebook.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Facebook.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IFacebookOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the cached, authenticated Facebook publishing client.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel client initialization.</param>
    /// <returns>The configured OpenAPI client.</returns>
    ValueTask<FacebookOpenApiClient> Get(CancellationToken cancellationToken = default);
}

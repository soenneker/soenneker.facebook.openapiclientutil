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
    ValueTask<FacebookOpenApiClient> Get(CancellationToken cancellationToken = default);
}

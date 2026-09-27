using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Facebook.HttpClients.Registrars;
using Soenneker.Facebook.OpenApiClientUtil.Abstract;

namespace Soenneker.Facebook.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class FacebookOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="FacebookOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddFacebookOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddFacebookOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IFacebookOpenApiClientUtil, FacebookOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="FacebookOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddFacebookOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddFacebookOpenApiHttpClientAsSingleton()
                .TryAddScoped<IFacebookOpenApiClientUtil, FacebookOpenApiClientUtil>();

        return services;
    }
}

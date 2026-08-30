using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Graph.Client.Abstract;

namespace Soenneker.Graph.Client.Registrars;

/// <summary>
/// Registers the Microsoft Graph client provider.
/// </summary>
public static class GraphClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IGraphClientUtil"/> as a singleton service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddGraphClientUtilAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<IGraphClientUtil, GraphClientUtil>();
        return services;
    }

    /// <summary>
    /// Adds <see cref="IGraphClientUtil"/> as a scoped service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddGraphClientUtilAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<IGraphClientUtil, GraphClientUtil>();
        return services;
    }
}

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Graph.Client.Abstract;

namespace Soenneker.Graph.Client.Registrars;

/// <summary>
/// An async thread-safe singleton for the Microsoft Graph client
/// </summary>
public static class GraphClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IGraphClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static void AddGraphClientUtilAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<IGraphClientUtil, GraphClientUtil>();
    }

    /// <summary>
    /// Adds <see cref="IGraphClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static void AddGraphClientUtilAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<IGraphClientUtil, GraphClientUtil>();
    }
}

using Microsoft.Graph;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Graph.Client.Abstract;

/// <summary>
/// An async thread-safe singleton for the Microsoft Graph client
/// </summary>
public interface IGraphClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Returns the configured graph Service Client used by the graph client.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested graph Service Client.</returns>
    ValueTask<GraphServiceClient> Get(CancellationToken cancellationToken = default);
}

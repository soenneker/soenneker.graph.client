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
    /// Gets the value.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<GraphServiceClient> Get(CancellationToken cancellationToken = default);
}
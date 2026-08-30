using Microsoft.Graph;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Graph.Client.Abstract;

/// <summary>
/// Provides one lazily initialized <see cref="GraphServiceClient"/> for the lifetime of the provider.
/// </summary>
public interface IGraphClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets or creates the client-credential-authenticated Microsoft Graph client.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>The client owned by this provider.</returns>
    ValueTask<GraphServiceClient> Get(CancellationToken cancellationToken = default);
}

using Microsoft.Graph;
using System;
using System.Threading.Tasks;

namespace Soenneker.Graph.Client.Abstract;

/// <summary>
/// An async thread-safe singleton for the Microsoft Graph client
/// </summary>
public interface IGraphClientUtil : IDisposable, IAsyncDisposable
{
    ValueTask<GraphServiceClient> Get();
}
using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using Soenneker.Extensions.Configuration;
using Soenneker.Graph.Client.Abstract;
using Soenneker.Utils.AsyncSingleton;
using System.Threading.Tasks;
using System;
using System.Threading;
using Microsoft.Extensions.Logging;

namespace Soenneker.Graph.Client;

/// <inheritdoc cref="IGraphClientUtil"/>
public sealed class GraphClientUtil : IGraphClientUtil
{
    private readonly AsyncSingleton<GraphServiceClient> _client;

    public GraphClientUtil(IConfiguration config, ILogger<GraphClientUtil> logger)
    {
        _client = new AsyncSingleton<GraphServiceClient>(() =>
        {
            logger.LogDebug("Connecting to Microsoft Graph...");

            // TODO: Move to better config location
            var tenantId = config.GetValueStrict<string>("Azure:AzureAd:TenantId");
            var clientId = config.GetValueStrict<string>("Azure:AzureAd:ClientId");
            var clientSecret = config.GetValueStrict<string>("Azure:AzureAd:ClientSecret");

            var credentials = new ClientSecretCredential(tenantId, clientId, clientSecret);
            return new GraphServiceClient(credentials);
        });
    }

    public ValueTask<GraphServiceClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }

    public void Dispose()
    {
        _client.Dispose();
    }
}
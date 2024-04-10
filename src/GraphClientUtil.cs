using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using Soenneker.Extensions.Configuration;
using Soenneker.Graph.Client.Abstract;
using Soenneker.Utils.AsyncSingleton;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using Soenneker.Extensions.ValueTask;

namespace Soenneker.Graph.Client;

/// <inheritdoc cref="IGraphClientUtil"/>
public class GraphClientUtil : IGraphClientUtil
{
    private readonly AsyncSingleton<GraphServiceClient> _client;

    public GraphClientUtil(IConfiguration config, ILogger<GraphClientUtil> logger)
    {
        _client = new AsyncSingleton<GraphServiceClient>(() =>
        {
            logger.LogDebug("Connecting to Microsoft Graph...");

            var tenantId = config.GetValueStrict<string>("Azure:B2C:TenantId");
            var clientId = config.GetValueStrict<string>("Azure:B2C:ClientId");
            var clientSecret = config.GetValueStrict<string>("Azure:B2C:ClientSecret");

            var credentials = new ClientSecretCredential(tenantId, clientId, clientSecret);
            return new GraphServiceClient(credentials);
        });
    }

    public ValueTask<GraphServiceClient> Get()
    {
        return _client.Get();
    }

    public async ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);

        await _client.DisposeAsync().NoSync();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        _client.Dispose();
    }
}
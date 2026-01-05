using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using Soenneker.Extensions.Configuration;
using Soenneker.Graph.Client.Abstract;
using Soenneker.Utils.AsyncSingleton;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Logging;

namespace Soenneker.Graph.Client;

/// <inheritdoc cref="IGraphClientUtil"/>
public sealed class GraphClientUtil : IGraphClientUtil
{
    private readonly ILogger<GraphClientUtil> _logger;

    private readonly string _tenantId;
    private readonly string _clientId;
    private readonly string _clientSecret;

    private readonly AsyncSingleton<GraphServiceClient> _client;

    public GraphClientUtil(IConfiguration config, ILogger<GraphClientUtil> logger)
    {
        _logger = logger;

        // Fail fast; no IConfiguration retained
        _tenantId = config.GetValueStrict<string>("Azure:AzureAd:TenantId");
        _clientId = config.GetValueStrict<string>("Azure:AzureAd:ClientId");
        _clientSecret = config.GetValueStrict<string>("Azure:AzureAd:ClientSecret");

        // No closure: method group
        _client = new AsyncSingleton<GraphServiceClient>(CreateClient);
    }

    private ValueTask<GraphServiceClient> CreateClient(CancellationToken token)
    {
        _logger.LogDebug("Connecting to Microsoft Graph...");

        var credentials = new ClientSecretCredential(_tenantId, _clientId, _clientSecret);

        return ValueTask.FromResult(new GraphServiceClient(credentials));
    }

    public ValueTask<GraphServiceClient> Get(CancellationToken cancellationToken = default) =>
        _client.Get(cancellationToken);

    public ValueTask DisposeAsync() => _client.DisposeAsync();

    public void Dispose() => _client.Dispose();
}
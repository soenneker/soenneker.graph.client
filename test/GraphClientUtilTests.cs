using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Graph;
using Soenneker.Facts.Local;
using Soenneker.Graph.Client.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;
using Xunit.Abstractions;

namespace Soenneker.Graph.Client.Tests;

[Collection("Collection")]
public class GraphClientUtilTests : FixturedUnitTest
{
    private readonly IGraphClientUtil _util;

    public GraphClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IGraphClientUtil>(true);
    }

    [LocalFact]
    public async Task Get_ReturnsNonNull()
    {
        GraphServiceClient client = await _util.Get();
        client.Should().NotBeNull();
    }
}

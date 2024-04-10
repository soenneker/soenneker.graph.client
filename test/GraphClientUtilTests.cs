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
}

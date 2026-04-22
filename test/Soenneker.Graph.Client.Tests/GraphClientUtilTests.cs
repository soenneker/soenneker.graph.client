using Soenneker.Graph.Client.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Graph.Client.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class GraphClientUtilTests : HostedUnitTest
{
    private readonly IGraphClientUtil _util;

    public GraphClientUtilTests(Host host) : base(host)
    {
        _util = Resolve<IGraphClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}

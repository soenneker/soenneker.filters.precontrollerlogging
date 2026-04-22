using Soenneker.Tests.HostedUnit;

namespace Soenneker.Filters.PreControllerLogging.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class PreControllerLoggingFilterTests : HostedUnitTest
{
    public PreControllerLoggingFilterTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}

using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Filters.PreControllerLogging.Tests;

[Collection("Collection")]
public sealed class PreControllerLoggingFilterTests : FixturedUnitTest
{
    public PreControllerLoggingFilterTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }

    [Fact]
    public void Default()
    {

    }
}

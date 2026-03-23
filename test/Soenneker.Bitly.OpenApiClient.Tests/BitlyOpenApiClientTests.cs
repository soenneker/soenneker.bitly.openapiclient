using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Bitly.OpenApiClient.Tests;

[Collection("Collection")]
public sealed class BitlyOpenApiClientTests : FixturedUnitTest
{
    public BitlyOpenApiClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }

    [Fact]
    public void Default()
    {

    }
}

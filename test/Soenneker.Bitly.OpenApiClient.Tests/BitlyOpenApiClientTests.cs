using Soenneker.Tests.HostedUnit;

namespace Soenneker.Bitly.OpenApiClient.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class BitlyOpenApiClientTests : HostedUnitTest
{
    public BitlyOpenApiClientTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}

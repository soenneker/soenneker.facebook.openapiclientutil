using Soenneker.Facebook.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Facebook.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class FacebookOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IFacebookOpenApiClientUtil _openapiclientutil;

    public FacebookOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IFacebookOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}

using Knx.Falcon.Discovery;

namespace KTMRemote.AppServices.KNX.Services;
public interface IKNXDiscoverIpDevices
{
    List<IpDeviceDiscoveryResult> DiscoverAsync(CancellationToken cancellation);
}
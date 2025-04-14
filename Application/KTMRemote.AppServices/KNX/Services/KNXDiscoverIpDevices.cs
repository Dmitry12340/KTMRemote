using Knx.Falcon;
using Knx.Falcon.Discovery;
using Knx.Falcon.Sdk;

namespace KTMRemote.AppServices.KNX.Services;
public class KNXDiscoverIpDevices : IKNXDiscoverIpDevices
{
    public List<IpDeviceDiscoveryResult> DiscoverAsync(CancellationToken cancellation)
    {
        var results = KnxBus.DiscoverIpDevicesAsync(cancellation).ToList(cancellation).Result;
        if (results != null)
        {
            foreach(var result in results)
            {
                Console.WriteLine(result);
            }
            return results;
        }
        else
            return null;
    }
}
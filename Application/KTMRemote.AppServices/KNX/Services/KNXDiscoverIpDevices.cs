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
                Console.WriteLine(result.ToConnectionString());
                Console.WriteLine("Individual Address = " + result.IndividualAddress.ToString());
                Console.WriteLine("Name = " + result.FriendlyName);
                Console.WriteLine("Programming Mode = " + result.IsInProgrammingMode);
                Console.WriteLine("IP Address = " + result.ControlEndpoint.Address);
                Console.WriteLine("Port = " + result.ControlEndpoint.Port);
            }
            return results;
        }
        else
            return null;
    }
}
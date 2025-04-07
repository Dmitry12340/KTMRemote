using Knx.Falcon.Configuration;
using Knx.Falcon.Sdk;
using KTMRemote.Contracts.KNXDto;

namespace KTMRemote.AppServices.KNX.Services;
public class KNXConnectService : IKNXConnectService
{
    public async Task ConnectAsync(KnxBus bus, CancellationToken cancellation)
    {
        await bus.ConnectAsync(cancellation);
    }

    public KnxBus CreateIpTunneling(KNXConnectDto connectDto)
    {
        IpTunnelingConnectorParameters ipTunneling = new IpTunnelingConnectorParameters(connectDto.Ip, connectDto.Port);
        return new KnxBus(ipTunneling);
    }
}
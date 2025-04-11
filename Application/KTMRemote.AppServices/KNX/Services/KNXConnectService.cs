using Knx.Falcon.Configuration;
using Knx.Falcon.Sdk;
using KTMRemote.Contracts.KNXDto;

namespace KTMRemote.AppServices.KNX.Services;
public class KNXConnectService : IKNXConnectService
{
    private KnxBus _bus;
    public KnxBus Bus => _bus;

    public async Task ConnectAsync(CancellationToken cancellation)
    {
        await _bus.ConnectAsync(cancellation);
    }

    public KnxBus CreateIpTunneling(KNXConnectDto connectDto)
    {
        IpTunnelingConnectorParameters ipTunneling = new IpTunnelingConnectorParameters(connectDto.Ip, connectDto.Port);
        _bus = new KnxBus(ipTunneling);
        return _bus;
    }
}
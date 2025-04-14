using Knx.Falcon.Configuration;
using Knx.Falcon.Sdk;
using KTMRemote.Contracts.KNXDto;

namespace KTMRemote.AppServices.KNX.Services;
public class KNXConnectService : IKNXConnectService
{
    private KnxBus _bus;
    public KnxBus Bus => _bus;

    public async Task ConnectAsync(KNXConnectDto connectDto, CancellationToken cancellation)
    {
        await CreateIpTunnelingAsync(connectDto, cancellation);

        if (_bus.ConnectionState != Knx.Falcon.BusConnectionState.Connected)
            await _bus.ConnectAsync(cancellation);
    }

    public async Task CreateIpTunnelingAsync(KNXConnectDto connectDto, CancellationToken cancellation)
    {
        await DisconnectAsync(cancellation);

        IpTunnelingConnectorParameters ipTunneling = new IpTunnelingConnectorParameters(connectDto.Ip, connectDto.Port);
        _bus = new KnxBus(ipTunneling);
    }

    public async Task DisconnectAsync(CancellationToken cancellation)
    {
        if (_bus != null)
            await _bus.DisposeAsync();
    }
}
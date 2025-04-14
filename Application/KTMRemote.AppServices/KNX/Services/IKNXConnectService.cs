using Knx.Falcon.Sdk;
using KTMRemote.Contracts.KNXDto;

namespace KTMRemote.AppServices.KNX.Services;
public interface IKNXConnectService
{
    KnxBus Bus { get; }
    Task ConnectAsync(KNXConnectDto connectDto, CancellationToken cancellation);
    Task CreateIpTunnelingAsync(KNXConnectDto connectDto, CancellationToken cancellation);
    Task DisconnectAsync(CancellationToken cancelToken);
}
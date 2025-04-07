using Knx.Falcon.Sdk;
using KTMRemote.Contracts.KNXDto;

namespace KTMRemote.AppServices.KNX.Services;
public interface IKNXConnectService
{
    Task ConnectAsync(KnxBus bus, CancellationToken cancellation);
    KnxBus CreateIpTunneling(KNXConnectDto connectDto);
}
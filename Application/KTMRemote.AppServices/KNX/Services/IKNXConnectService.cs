using Knx.Falcon.Sdk;
using KTMRemote.Contracts.KNXDto;

namespace KTMRemote.AppServices.KNX.Services;
public interface IKNXConnectService
{
    KnxBus Bus { get; }
    Task ConnectAsync(CancellationToken cancellation);
    KnxBus CreateIpTunneling(KNXConnectDto connectDto);
}
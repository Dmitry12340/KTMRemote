using Knx.Falcon;
using KTMRemote.Contracts.KNXDto;

namespace KTMRemote.AppServices.KNX.Services;

public class DataExchangeWithBus : IDataExchangeWithBus
{
    private readonly IKNXConnectService _knxConnectService;
    public DataExchangeWithBus(IKNXConnectService knxConnectService)
    {
        _knxConnectService = knxConnectService;
    }
    public async Task<bool> WriteGroupAsync(KNXMassageDto massageDto, CancellationToken cancellation)
    {
        GroupAddress address = massageDto.Address;
        GroupValue value = new GroupValue(massageDto.Value);
        MessagePriority priority = (MessagePriority)massageDto.Priority;
        bool result = await _knxConnectService.Bus.WriteGroupValueAsync(address, value, priority, cancellation);
        return result;
    }
}

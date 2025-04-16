using KTMRemote.Contracts.KNXDto;

namespace KTMRemote.AppServices.KNX.Services;
public interface IKNXDiscoverIpDevicesService
{
    List<DiscoverDeviceDto> DiscoverAsync(CancellationToken cancellation);
}
using Knx.Falcon;
using Knx.Falcon.Sdk;
using KTMRemote.Contracts.KNXDto;

namespace KTMRemote.AppServices.KNX.Services;
public class KNXDiscoverIpDevicesService : IKNXDiscoverIpDevicesService
{
    public List<DiscoverDeviceDto> DiscoverAsync(CancellationToken cancellation)
    {
        var results = KnxBus.DiscoverIpDevicesAsync(cancellation).ToList(cancellation).Result;
        var dtos = new List<DiscoverDeviceDto>();

        if (results != null)
        {
            foreach(var result in results)
            {
                DiscoverDeviceDto dto = new DiscoverDeviceDto();
                dto.Name = result.FriendlyName;
                dto.IndividualAddress = result.IndividualAddress;
                dto.ProgrammingMode = result.IsInProgrammingMode;
                dto.Ip = result.ControlEndpoint.Address.ToString();
                dto.Port = result.ControlEndpoint.Port;
                dtos.Add(dto);
            }
            return dtos;
        }
        else
            return null;
    }
}
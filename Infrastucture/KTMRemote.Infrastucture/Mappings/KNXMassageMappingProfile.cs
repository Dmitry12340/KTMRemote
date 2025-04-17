using AutoMapper;
using KTMRemote.Contracts.KNXDto;
//using KTMRemote.MVC.Models;

namespace KTMRemote.Infrastucture.Mappings;

public sealed class KNXMassageMappingProfile : Profile
{
    public KNXMassageMappingProfile()
    {
        /*CreateMap<KNXGroupModel, KNXMassageDto>()
            .ForMember(dest => dest.Address, o => o.MapFrom(src => src.address))
            .ForMember(dest => dest.Value, o => o.MapFrom(src => src.value));*/
    }
}

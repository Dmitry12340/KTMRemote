using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using KTMRemote.AppServices.KNX.Services;
using AutoMapper;
using KTMRemote.Infrastucture.Mappings;

namespace KTMRemote.ComponentRegistrar;
public static class Registrar
{
    public static void AddComponents(IServiceCollection services, IConfiguration configuration)
    {
        RegisterServices(services);
        RegisterMapper(services, configuration);
    }

    private static void RegisterServices(IServiceCollection services)
    {
        services.AddSingleton<IKNXConnectService, KNXConnectService>();
        services.AddScoped<IDataExchangeWithBus, DataExchangeWithBus>();
        services.AddScoped<IKNXDiscoverIpDevicesService, KNXDiscoverIpDevicesService>();
    }

    private static void RegisterMapper(IServiceCollection services, IConfiguration configuration)
    {
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new KNXMassageMappingProfile());
        });

        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);
    }
}
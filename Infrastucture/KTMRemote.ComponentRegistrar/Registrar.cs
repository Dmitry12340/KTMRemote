using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using KTMRemote.AppServices.KNX.Services;

namespace KTMRemote.ComponentRegistrar;
public static class Registrar
{
    public static void AddComponents(IServiceCollection services, IConfiguration configuration)
    {
        RegisterServices(services);
    }

    private static void RegisterServices(IServiceCollection services)
    {
        services.AddSingleton<IKNXConnectService, KNXConnectService>();
        services.AddScoped<IKNXDiscoverIpDevices, KNXDiscoverIpDevices>();
    }
}
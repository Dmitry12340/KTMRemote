using KTMRemote.Contracts.KNXDto;

namespace KTMRemote.AppServices.KNX.Services;

/// <summary>
/// Сервис поиска Ip интерфейсов knx.
/// </summary>
public interface IKNXDiscoverIpDevicesService
{
    /// <summary>
    /// Поиск Ip интерфейсов knx в локальной сети.
    /// </summary>
    /// <param name="cancellation">Токен отмены.</param>
    /// <returns>Коллекция транспортной модели.</returns>
    List<DiscoverDeviceDto> DiscoverAsync(CancellationToken cancellation);
}
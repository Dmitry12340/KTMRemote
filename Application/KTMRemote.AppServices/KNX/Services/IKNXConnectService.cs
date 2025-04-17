using Knx.Falcon.Sdk;
using KTMRemote.Contracts.KNXDto;

namespace KTMRemote.AppServices.KNX.Services;
/// <summary>
/// Сервис поключения к интерфейсу knx
/// </summary>
public interface IKNXConnectService
{
    /// <summary>
    /// Свойство, содержащее подключение к интерфейсу knx.
    /// </summary>
    KnxBus Bus { get; }

    /// <summary>
    /// Подключение к интерфейсу knx.
    /// </summary>
    /// <param name="connectDto">Транспортная модель.</param>
    /// <param name="cancellation">Токен отмены.</param>
    Task ConnectAsync(KNXConnectDto connectDto, CancellationToken cancellation);

    /// <summary>
    /// Отключение от интерфейса knx.
    /// </summary>
    /// <param name="cancelToken">Токен отмены.</param>
    Task DisconnectAsync(CancellationToken cancelToken);
}
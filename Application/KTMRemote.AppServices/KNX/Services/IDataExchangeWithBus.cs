using KTMRemote.Contracts.KNXDto;

namespace KTMRemote.AppServices.KNX.Services;

/// <summary>
/// Сервис для обмена сообщениями с интерфейсом knx.
/// </summary>
public interface IDataExchangeWithBus
{
    /// <summary>
    /// Отправка сообщений интерфейсу knx.
    /// </summary>
    /// <param name="massageDto">Транспортная модель.</param>
    /// <param name="cancellation">Токен отмены.</param>
    /// <returns>Результат отправки.</returns>
    Task<bool> WriteGroupAsync(KNXMassageDto massageDto, CancellationToken cancellation);
}

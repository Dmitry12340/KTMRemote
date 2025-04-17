namespace KTMRemote.Contracts.KNXDto;
/// <summary>
/// Транспортная модель соединения с интерфейсом knx.
/// </summary>
public sealed class KNXConnectDto
{
    /// <summary>
    /// Ip адрес интерфейса knx.
    /// </summary>
    public string Ip { get; set; }

    /// <summary>
    /// Порт интерфейса knx.
    /// </summary>
    public int Port { get; set; }
}
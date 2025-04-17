namespace KTMRemote.Contracts.KNXDto;
/// <summary>
/// Транспортная модель интерфейса knx.
/// </summary>
public sealed class DiscoverDeviceDto
{
    /// <summary>
    /// Имя интерфейса knx.
    /// </summary>
    public string Name;

    /// <summary>
    /// Индивидуальный адрес интерфейса knx.
    /// </summary>
    public string IndividualAddress;

    /// <summary>
    /// Режим программирования интерфейса knx.
    /// </summary>
    public bool ProgrammingMode;

    /// <summary>
    /// Ip адрес интерфейса knx.
    /// </summary>
    public string Ip;

    /// <summary>
    /// Порт интерфейса knx.
    /// </summary>
    public int Port;
}
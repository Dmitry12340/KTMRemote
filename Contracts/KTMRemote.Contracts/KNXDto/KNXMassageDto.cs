namespace KTMRemote.Contracts.KNXDto;
/// <summary>
/// Транспортная модель сообщения интерфейсу knx.
/// </summary>
public class KNXMassageDto
{
    /// <summary>
    /// Групповой адрес.
    /// </summary>
    public string Address { get; set; } = "0/0/0";

    /// <summary>
    /// Значение.
    /// </summary>
    public byte Value { get; set; } = 0;

    /// <summary>
    /// Приоритет сообщения.
    /// </summary>
    public Priority Priority { get; set; } = Priority.Low;
}

/// <summary>
/// Приоритет сообщения для интерфейса knx.
/// </summary>
public enum Priority
{
    System = 0,
    High = 1,
    Alarm = 2,
    Low = 3
}
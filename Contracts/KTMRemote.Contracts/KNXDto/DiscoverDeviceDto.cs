namespace KTMRemote.Contracts.KNXDto;
public sealed class DiscoverDeviceDto
{
    public string Name;
    public string IndividualAddress;
    public bool ProgrammingMode;
    public string Ip;
    public int Port;

    public override string ToString() =>
        $"Name:{Name}\n" +
        $"IndividualAddress:{IndividualAddress}\n" +
        $"ProgrammingMode:{ProgrammingMode}\n" +
        $"Ip:{Ip}\n" +
        $"Port:{Port}";
}
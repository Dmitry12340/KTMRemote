using KTMRemote.Contracts.KNXDto;
using KTMRemote.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using KTMRemote.AppServices.KNX.Services;

namespace KTMRemote.MVC.Controllers;
public class KNXController : Controller
{
    private readonly IKNXConnectService _knxConnectService;
    private readonly IKNXDiscoverIpDevicesService _knxDiscoverIpDevices;
    private readonly IDataExchangeWithBus _dataExchangeWithBus;
    public KNXController(IKNXConnectService knxConnectService,
        IKNXDiscoverIpDevicesService knxDiscoverIpDevices,
        IDataExchangeWithBus dataExchangeWithBus)
    {
        _knxConnectService = knxConnectService;
        _knxDiscoverIpDevices = knxDiscoverIpDevices;
        _dataExchangeWithBus = dataExchangeWithBus;
    }

    [HttpGet]
    public IActionResult KNXMenu()
    {
        return View();
    }

    [HttpGet]
    public IActionResult KNXWrite()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> KNXWrite(KNXMassageDto model, CancellationToken cancellation)
    {
        await _dataExchangeWithBus.WriteGroupAsync(model, cancellation);

        return View();
    }

    [HttpGet]
    public IActionResult KNXConnect()
    {
        UpdateConnectionState();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> KNXConnect(KNXConnectModel model, CancellationToken cancellation)
    {
        await _knxConnectService.ConnectAsync(new KNXConnectDto { Ip = model.Ip, Port = model.Port }, cancellation);

        UpdateConnectionState();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> KNXDisconnect(CancellationToken cancellation)
    {
        await _knxConnectService.DisconnectAsync(cancellation);

        UpdateConnectionState();
        return View("KNXConnect");
    }

    [HttpGet]
    public IActionResult KNXDiscover()
    {
        return View();
    }

    [HttpPost]
    public IActionResult KNXDiscover(CancellationToken cancellation)
    {
        List<DiscoverDeviceDto> dtos = _knxDiscoverIpDevices.DiscoverAsync(cancellation);
        return View(dtos);
    }

    private void UpdateConnectionState()
    {
        ViewBag.State = "Closed";
        if (_knxConnectService.Bus != null)
            ViewBag.State = _knxConnectService.Bus.ConnectionState;
    }
}
using Knx.Falcon;
using KTMRemote.Contracts.KNXDto;
using KTMRemote.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using KTMRemote.AppServices.KNX.Services;

namespace KTMRemote.MVC.Controllers;
public class KNXController : Controller
{
    private readonly IKNXConnectService _knxConnectService;
    private readonly IKNXDiscoverIpDevicesService _knxDiscoverIpDevices;
    public KNXController(IKNXConnectService knxConnectService, IKNXDiscoverIpDevicesService knxDiscoverIpDevices)
    {
        _knxConnectService = knxConnectService;
        _knxDiscoverIpDevices = knxDiscoverIpDevices;
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
    public async Task<IActionResult> KNXWrite(KNXGroupModel model, CancellationToken cancellation)
    {
        GroupAddress address = new GroupAddress(model.address);
        GroupValue value = new GroupValue(model.value);

        MessagePriority messagePriority = MessagePriority.Low;

        await _knxConnectService.Bus.WriteGroupValueAsync(address, value, messagePriority);

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
    public async Task<IActionResult> KNXDiscover(CancellationToken cancellation)
    {
        List<DiscoverDeviceDto> dtos = _knxDiscoverIpDevices.DiscoverAsync(cancellation);
        Console.WriteLine();
        foreach (var dto in dtos)
        {
            Console.WriteLine(dto.ToString());
        }
        return View(dtos);
    }

    private void UpdateConnectionState()
    {
        ViewBag.State = "Closed";
        if (_knxConnectService.Bus != null)
            ViewBag.State = _knxConnectService.Bus.ConnectionState;
    }
}
using Knx.Falcon.Sdk;
using Knx.Falcon;
using KTMRemote.Contracts.KNXDto;
using KTMRemote.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using KTMRemote.AppServices.KNX.Services;

namespace KTMRemote.MVC.Controllers;
public class KNXController : Controller
{

    private readonly IKNXConnectService _knxConnectService;
    private readonly IKNXDiscoverIpDevices _knxDiscoverIpDevices;
    public KNXController(IKNXConnectService knxConnectService, IKNXDiscoverIpDevices knxDiscoverIpDevices)
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
        /*KNXConnectDto dto = new KNXConnectDto { Ip = "192.168.8.134", Port = 3671 };
        KnxBus bus = _knxConnectService.CreateIpTunneling(dto);


        var devices = _knxDiscoverIpDevices.DiscoverAsync(cancellation);*/


        GroupAddress address = new GroupAddress(model.address);
        GroupValue value = new GroupValue(model.value);

        MessagePriority messagePriority = MessagePriority.Low;

        await _knxConnectService.Bus.WriteGroupValueAsync(address, value, messagePriority);

        return Ok();
    }

    [HttpGet]
    public IActionResult KNXConnect()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> KNXConnect(KNXConnectModel model, CancellationToken cancellation)
    {
        var ipTunneling = _knxConnectService.CreateIpTunneling(new KNXConnectDto { Ip = model.Ip, Port = model.Port });
        await _knxConnectService.ConnectAsync(cancellation);
        return View();
    }
}
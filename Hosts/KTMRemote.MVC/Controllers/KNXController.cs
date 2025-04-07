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
    public KNXController(IKNXConnectService knxConnectService)
    {
        _knxConnectService = knxConnectService;
    }

    [HttpGet]
    public IActionResult KNXMenu()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> KNXWrite(KNXGroupModel model, CancellationToken cancellation)
    {
        KNXConnectDto dto = new KNXConnectDto { Ip = "192.168.8.134", Port = 3671 };
        KnxBus bus = _knxConnectService.CreateIpTunneling(dto);

        var ipDeviceDiscoveryResults = KnxBus.DiscoverIpDevicesAsync(cancellation);
        var devices = ipDeviceDiscoveryResults.ToList(cancellation);
        for(int i = 0; i < devices.Result.Count; i++)
        {
            Console.WriteLine(devices.Result[i]);
        }

        await _knxConnectService.ConnectAsync(bus, cancellation);


        GroupAddress address = new GroupAddress(model.address);
        GroupValue value = new GroupValue(model.value);

        MessagePriority messagePriority = MessagePriority.Low;

        await bus.WriteGroupValueAsync(address, value, messagePriority, cancellation);


        return Ok();
    }
}
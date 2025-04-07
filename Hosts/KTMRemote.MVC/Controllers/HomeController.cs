using Knx.Falcon.Configuration;
using Knx.Falcon.Sdk;
using Knx.Falcon;
using KTMRemote.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using KTMRemote.AppServices.KNX.Services;
using KTMRemote.Contracts.KNXDto;

namespace KTMRemote.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IKNXConnectService _knxConnectService;

        public HomeController(ILogger<HomeController> logger, IKNXConnectService knxConnectService)
        {
            _logger = logger;
            _knxConnectService = knxConnectService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult KNXMenu()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> KNXWrite(KNXGroupModel model, CancellationToken cancellation)
        {
            KNXConnectDto dto = new KNXConnectDto { Ip = "192.168.8.132", Port = 3671 };
            KnxBus bus = _knxConnectService.CreateIpTunneling(dto);
            await _knxConnectService.ConnectAsync(bus, cancellation);

            GroupAddress address = new GroupAddress(model.address);
            GroupValue value = new GroupValue(model.value);

            MessagePriority messagePriority = MessagePriority.High;

            await bus.WriteGroupValueAsync(address, value, messagePriority, cancellation);


            return Ok();
        }
    }
}

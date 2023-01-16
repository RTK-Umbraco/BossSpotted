using BossSpotted.Hubs;
using BossSpotted.Hubs.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BossSpotted.Controllers
{
    public class BossSpottedController : Controller
    {
        private readonly IBossSpottedHub _bossSpottedHub;
        public BossSpottedController(IBossSpottedHub bossSpottedHub)
        {
            _bossSpottedHub = bossSpottedHub;
        }
        public async Task<IActionResult> Index()
        {
            //this.HubContext.Clients.All.InvokeAsync("Completed");
            await _bossSpottedHub.SendMessage("Daniel", "Benjamin");
            return View();
        }
    }
}

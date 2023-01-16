using BossSpotted.Hubs;
using BossSpotted.Hubs.Interface;
using BossSpotted.Models.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BossSpotted.Controllers
{
    public class BossSpottedController : Controller
    {
        private readonly IBossSpottedModel _bossSpottedModel;

        public BossSpottedController(IBossSpottedModel bossSpottedModel)
        {
            _bossSpottedModel = bossSpottedModel;
        }

        public async Task<IActionResult> Index()
        {
            await _bossSpottedModel.Spotted();
            return View();
        }
    }
}

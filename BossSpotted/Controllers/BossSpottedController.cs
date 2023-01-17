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
        [HttpPost("BossSpotted/{id}/{seriousness}")]
        public async Task<IActionResult> Index(int id, int seriousness)
        {
            var isNewSigthingRegistered = _bossSpottedModel.BossSpotted(id, seriousness);
            return Json(isNewSigthingRegistered);

        }
    }
}

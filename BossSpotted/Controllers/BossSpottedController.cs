using BossSpotted.Models.BusinessDomain.Sightings;
using BossSpotted.Models.EntityFramework;
using BossSpotted.Models.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BossSpotted.Controllers
{
    public class BossSpottedController : Controller
    {
        private readonly IBossSpottedModel _bossSpottedModel;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<BossSpottedController> _logger;
        private BossSpottedContext _context;

        public BossSpottedController(IBossSpottedModel bossSpottedModel, ILoggerFactory loggerFactory,BossSpottedContext context)
        {
            _bossSpottedModel = bossSpottedModel;
            this._loggerFactory = loggerFactory;
            this._logger = loggerFactory.CreateLogger<BossSpottedController>();
            this._context = context;
        }
        [HttpPost("BossSpotted/{id}/{seriousness}")]
        public async Task<IActionResult> Index(int id, int seriousness)
        {
            await _bossSpottedModel.BossSpotted();
            RegisterNewSighting registerNewSighting = new RegisterNewSighting(this._loggerFactory, this._context);
            bool result = registerNewSighting.Register(id, (SightingSeriousness)seriousness);
            return Json(result);
        }
    }
}

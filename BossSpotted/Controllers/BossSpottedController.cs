using BossSpotted.Hubs.Interface;
using BossSpotted.Models;
using BossSpotted.Models.EntityFramework;
using BossSpotted.Models.Validations;
using Microsoft.AspNetCore.Mvc;

namespace BossSpotted.Controllers
{
    public class BossSpottedController : Controller
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly BossSpottedContext _context;
        private readonly IBossSpottedHub _bossSpottedHub;
        private readonly InputValidation _inputValidation;

        public BossSpottedController(ILoggerFactory loggerFactory, BossSpottedContext context, 
            IBossSpottedHub bossSpottedHub, InputValidation inputValidation)
        {
            this._loggerFactory = loggerFactory;
            this._context = context;
            this._bossSpottedHub = bossSpottedHub;
            this._inputValidation = inputValidation;
        }
        [HttpPost("BossSpotted/{id}/{seriousness}")]
        public async Task<IActionResult> Index(int id, int seriousness)
        {
            if (!this._inputValidation.ValidateSightingSeriousness(seriousness))
                return BadRequest();

            BossSpottedModel bossSpotted = new BossSpottedModel(this._loggerFactory, this._context);
            var isNewSigthingRegistered = bossSpotted.BossSpotted(id, seriousness);

            await this._bossSpottedHub.BossSpotted((SightingSeriousness)seriousness);

            return Ok();
        }
    }
}

using BossSpotted.Models.BusinessDomain;
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

        public async Task<IActionResult> Index()
        {
            await _bossSpottedModel.BossSpotted();
            CreateNewSighting test = new CreateNewSighting(this._loggerFactory, this._context);
            test.Create(20);
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace BossSpotted.Hubs.Interface
{
    public interface IBossSpottedHub
    {
        Task<IActionResult> Index();
    }
}

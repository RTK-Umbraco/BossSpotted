using BossSpotted.Hubs.Interface;
using Microsoft.AspNetCore.SignalR;

namespace BossSpotted.Hubs
{
    public class BossSpottedHub : Hub, IBossSpottedHub
    {
        private readonly IHubContext<BossSpottedHub> _hubContext;
        public BossSpottedHub(IHubContext<BossSpottedHub> hubContext)
        {
            this._hubContext = hubContext;
        }
        public async Task BossSpotted()
        {
            await _hubContext.Clients.All.SendAsync("BossHasBeenSpotted");
        }
    }
}
 
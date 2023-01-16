using BossSpotted.Hubs.Interface;
using Microsoft.AspNetCore.SignalR;

namespace BossSpotted.Hubs
{
    public class BossSpottedHub : Hub, IBossSpottedHub
    {
        IHubContext<BossSpottedHub> _hubContext;
        public BossSpottedHub(IHubContext<BossSpottedHub> hubContext)
        {
            this._hubContext = hubContext;
        }
        public async Task SendMessage(string user, string message)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
 
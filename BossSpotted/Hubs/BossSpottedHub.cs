using Microsoft.AspNetCore.SignalR;

namespace BossSpotted.Hubs
{
    public class BossSpottedHub : Hub
    {
        IHubContext<BossSpottedHub> _hubContext;
        public BossSpottedHub(IHubContext<BossSpottedHub> hubContext)
        {
            this._hubContext = hubContext;
        }
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
 
using Microsoft.AspNetCore.Mvc;

namespace BossSpotted.Hubs.Interface
{
    public interface IBossSpottedHub
    {
        Task SendMessage(string user, string message);
    }
}

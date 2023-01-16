using BossSpotted.Hubs.Interface;
using BossSpotted.Models.Interface;

namespace BossSpotted.Models
{
    public class BossSpottedModel : IBossSpottedModel
    {
        private readonly IBossSpottedHub _bossSpottedHub;

        public BossSpottedModel(IBossSpottedHub bossSpottedHub)
        {
            _bossSpottedHub = bossSpottedHub;
        }

        public async Task BossSpotted()
        {
            await _bossSpottedHub.BossSpotted();
        }
    }
}

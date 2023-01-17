namespace BossSpotted.Models.Interface
{
    public interface IBossSpottedModel
    {
        Task BossSpotted(int id, int seriousness);
    }
}

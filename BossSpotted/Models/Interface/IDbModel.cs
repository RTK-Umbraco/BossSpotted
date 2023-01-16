namespace BossSpotted.Models.Interface
{
    public interface IDbModel
    {
        DateTime CreatedTimeStamp { get; set; } 
        DateTime? DeletedTimeStamp { get; set; }
    }
}

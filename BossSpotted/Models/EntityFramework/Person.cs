using BossSpotted.Models.Interface;

namespace BossSpotted.Models.EntityFrameWork
{
    public partial class Person : IDbModel
    {
        public DateTime CreatedTimeStamp { get; set; } = DateTime.Now;
        public DateTime? DeletedTimeStamp { get; set; }
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BossSpotted.Models.Interface;

namespace BossSpotted.Models.EntityFrameWork
{
    public partial class Person : IDbModel
    {
        public DateTime CreatedTimeStamp { get; set; } = DateTime.Now.ToUniversalTime();
        public DateTime? DeletedTimeStamp { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}

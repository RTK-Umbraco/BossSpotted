using BossSpotted.Models.EntityFrameWork;
using Microsoft.Extensions.Options;
using System.Data.Entity;

namespace BossSpotted.Models.EntityFramework
{
    public class BossSpottedContext : DbContext
    {
        public BossSpottedContext(IOptions<BossSpottedOptions> options) 
            : base(options.Value.DbConnectionString)
        {
            //Database.SetInitializer<BossSpottedContext>(new DropCreateDatabaseAlways<BossSpottedContext>());
            //Database.SetInitializer<BossSpottedContext>(new CreateDatabaseIfNotExists<BossSpottedContext>());
            Database.SetInitializer<BossSpottedContext>(new DropCreateDatabaseIfModelChanges<BossSpottedContext>());
            
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Sighting> Sightings { get; set; }
    }
}

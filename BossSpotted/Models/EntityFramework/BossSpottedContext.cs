using BossSpotted.Models.EntityFrameWork;
using Microsoft.Extensions.Options;
using System.Data.Entity;

namespace BossSpotted.Models.EntityFramework
{
    public class BossSpottedContext : DbContext
    {
        public BossSpottedContext(IOptions<ApplicationSettings> options) 
            : base(options.Value.bossSpottedOptions.DbConnectionString)
        {
            //Database.SetInitializer<BossSpottedContext>(new DropCreateDatabaseAlways<BossSpottedContext>());
            //Database.SetInitializer<BossSpottedContext>(new CreateDatabaseIfNotExists<BossSpottedContext>());
            Database.SetInitializer<BossSpottedContext>(new DropCreateDatabaseIfModelChanges<BossSpottedContext>());
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Sighting> Sightings { get; set; }
        public DbSet<SightingSeriousness> SightingsSeriousness { get; set; }
    }
}

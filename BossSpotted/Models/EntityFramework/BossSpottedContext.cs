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

        }

        public DbSet<Person> persons { get; set; }
        public DbSet<Sighting> Sightings { get; set; }
    }
}

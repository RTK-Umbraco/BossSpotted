using BossSpotted.Models.EntityFramework;
using BossSpotted.Models.EntityFrameWork;

namespace BossSpotted.Models.BusinessDomain.Sightings
{
    public class RegisterNewSighting
    {
        private readonly ILogger<RegisterNewSighting> _logger;
        private readonly ILoggerFactory _loggerFactory;
        private readonly BossSpottedContext _context;
        public RegisterNewSighting(ILoggerFactory loggerFactory, BossSpottedContext context)
        {
            _logger = loggerFactory.CreateLogger<RegisterNewSighting>();
            _loggerFactory = loggerFactory;
            _context = context;
        }

        public bool Register(int personId, SightingSeriousness seriousness)
        {
            this._logger.LogInformation("Registering new sighting");
            Person person = GetOrSetPerson(personId);
            Sighting sighting = new Sighting()
            {
                PersonSighted = person,
                SightingSeriousness = seriousness
            };
            _context.Sightings.Add(sighting);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "Could not save changes");
                return false;
            }

            return true;
        }
        private Person GetOrSetPerson(int personId)
        {
            return _context.Persons.FirstOrDefault(x => x.Id == personId) ?? _context.Persons.Add(new Person() { Id = personId });
        }



    }
}

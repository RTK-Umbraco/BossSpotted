using BossSpotted.Models.EntityFramework;
using BossSpotted.Models.EntityFrameWork;
using System;

namespace BossSpotted.Models.BusinessDomain.Persons
{
    public class PersonControllerHelper
    {
        private ILoggerFactory _loggerFactory;
        private ILogger<PersonControllerHelper> _logger; 
        private BossSpottedContext _context;
        public PersonControllerHelper(ILoggerFactory loggerFactory, BossSpottedContext context)
        {
            _loggerFactory = loggerFactory;
            this._logger = loggerFactory.CreateLogger<PersonControllerHelper>();
            _context = context;
        }

        public IEnumerable<Person?> GetPersons()
        {
            return _context.Persons.NotDeleted();
        }

        public Person? GetPerson(int id)
        {
            Person? person = _context.Persons.NotDeleted().FirstOrDefault(x => x.Id == id);

            if (person == null)
            {
                return null;
            }

            return person;
        }

        //Id needs to be defined here in order to not create multiple people with the same id.
        //Todo: Find a way to defer people create from controller, and from sightings in BossSpottedController.
        public Person? CreatePerson(int id, string? firstName, string? lastName)
        {
            Person person = this._context.Persons.Add(new Person() {Id = id, FirstName = firstName, LastName = lastName });
            try
            {
                this._context.SaveChanges();

            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "Could not save new person");
                throw;
            }

            return person;
        }

        public Person? EditPerson(int id, string? firstName, string? lastName)
        {
            Person person = this._context.Persons.NotDeleted().FirstOrDefault(x => x.Id == id);

            if (person == null)
            {
                return null;
            }

            person.FirstName = firstName;
            person.LastName = lastName;

            try
            {
                this._context.SaveChanges();

            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "Could not save new person");
                throw;
            }
            return person;
        }

        public Person? DeletePerson(int id)
        {
            Person? person = this.GetPerson(id);

            if (person == null)
            {
                return null;
            }
            person.MarkDeleted();

            try
            {
                this._context.SaveChanges();

            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "Could not delete person");
                throw;
            }
            return person;
        }
    }
}

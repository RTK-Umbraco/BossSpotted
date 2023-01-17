using BossSpotted.Models.EntityFramework;
using BossSpotted.Models.EntityFrameWork;

namespace BossSpotted.Models.BusinessDomain
{
    public class CreateNewSighting
    {
        private ILogger<CreateNewSighting> _logger;
        private readonly ILoggerFactory _loggerFactory;
        private BossSpottedContext _context;
        public CreateNewSighting(ILoggerFactory loggerFactory, BossSpottedContext context)
        {
            this._logger = loggerFactory.CreateLogger<CreateNewSighting>();
            this._loggerFactory = loggerFactory;
            this._context = context;
        }

        public void Create(int personId)
        {
            try
            {
                Person person = this._context.Persons.FirstOrDefault(x => x.Id == personId) ??
                                new Person();
                this._context.Persons.Add(person);
                this._context.SaveChanges();
                var i = this._context.Persons.ToList();

            }
            catch (Exception ex)
            {

            }
        }


    }
}

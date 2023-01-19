using System.Net;
using BossSpotted.Models.BusinessDomain.Persons;
using BossSpotted.Models.EntityFramework;
using BossSpotted.Models.EntityFrameWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BossSpotted.Controllers
{
    public class PersonController : Controller
    {
        private ILoggerFactory _loggerFactory;
        private BossSpottedContext _context;
        private PersonControllerHelper personQueryHelper;
        public PersonController(ILoggerFactory loggerFactory, BossSpottedContext context)
        {
            _loggerFactory = loggerFactory;
            _context = context;
            this.personQueryHelper = new PersonControllerHelper(loggerFactory, context);
        }

        [HttpGet]
        public ActionResult Index()
        {
            return Json(this.personQueryHelper.GetPersons());
        }

        [HttpGet]
        public ActionResult<Model> Details(int id)
        {
            Person? person = this.personQueryHelper.GetPerson(id);
            if (person == null)
                return BadRequest();
            return Json(person);
        }

        [HttpPut]
        public ActionResult Create(int id, string firstName, string lastName)
        {
            Person? person = this.personQueryHelper.CreatePerson(id, firstName, lastName);
            if (person == null)
                return BadRequest();
            return Json(person);
        }

        [HttpPut]
        public ActionResult Edit(int id, string? firstName, string? lastName)
        {
            Person? person = this.personQueryHelper.EditPerson(id, firstName, lastName);
            if (person == null)
                return BadRequest();
            return Json(person);
        }
        
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Person? person = this.personQueryHelper.DeletePerson(id);
            if (person == null)
                return BadRequest();
            return Json(person);
        }
    }
}

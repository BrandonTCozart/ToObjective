using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToObjective.Data;
using ToObjective.Models;

namespace ToObjective.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]
    public class ObjectiveController : Controller
    {
        /*
        private readonly ObjectiveDbContext _db;

        public ObjectiveController(ObjectiveDbContext db)
        {
            _db = db;
        }
        */
        private readonly DataAccess _dataAccess;

        public ObjectiveController(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        
        public IActionResult Index()
        {
            //IEnumerable<Objective> objectivesList = _db.Objectives;
            return View(_dataAccess.getObjectives());
        }

        public IActionResult addNew()
        {
            return View();
        }
        public IActionResult edit()
        {
            return View();
        }

        [HttpGet]
        public IActionResult getIndex()
        {
            return Json(_dataAccess.getObjectives());
        }

        /*
        [HttpPost]
        public IActionResult postIndex(string title,string description,string completeByDate)
        {
            Objective obj = new Objective(title, description, DateTime.Parse(completeByDate));
            DbSet<Objective> objectivesList = _db.Objectives;
            objectivesList.Add(obj);
            _db.Objectives = objectivesList;
            _db.SaveChanges();
            return new EmptyResult();
        }
        */
        // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/ //

        [HttpDelete]
        public IActionResult delete(int id) {
            _dataAccess.deleteObjective(id);
            return new EmptyResult();
        }

        [HttpPut]
        public IActionResult completeObjective(int id)
        {
            _dataAccess.completeObjective(id);
            return new EmptyResult();
        }

        /*
        [HttpPut]

        public IActionResult editObjective(int id, string title, string description, string date)
        {
            var result = _db.Objectives.Where(x => x.Id == id).First();
            result.Title = title;
            result.Description = description;
            result.CompleteByDate = DateTime.Parse(date);
            _db.SaveChanges();
            return new EmptyResult();
        }
        */
    }
}

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
        private readonly ObjectiveDbContext _db;

        public ObjectiveController(ObjectiveDbContext db)
        {
            _db = db;
        }

        
        public IActionResult Index()
        {
            IEnumerable<Objective> objectivesList = _db.Objectives;
            return View(objectivesList);
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
            IEnumerable<Objective> objectivesList = _db.Objectives;
            return Json(objectivesList);
        }

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
        // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/ //

        [HttpDelete]
        public IActionResult delete(int id) {
            DbSet<Objective> objectivesList = _db.Objectives;

            foreach (Objective obj in objectivesList)
            {
                if (obj.Id == id)
                {
                    _db.Objectives.Remove(obj);
                    _db.SaveChanges();
                }
            }
            return new EmptyResult();
        }

        [HttpPut]
        public IActionResult completeObjective(int id)
        {
            var result = _db.Objectives.Where(x => x.Id == id).First();
            result.CompletedDate = DateTime.Now;
            result.UpdatedDate = DateTime.Now;
            _db.SaveChanges();
            return new EmptyResult();
        }

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

    }
}

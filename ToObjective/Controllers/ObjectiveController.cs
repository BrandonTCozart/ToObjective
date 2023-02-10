using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToObjective.Data;
using ToObjective.Interfaces;
using ToObjective.Models;

namespace ToObjective.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]
    public class ObjectiveController : Controller
    {
        private readonly IObjectiveInterface _dataAccess;

        public ObjectiveController(IObjectiveInterface dataAccess)
        {
            this._dataAccess = dataAccess;
        }
        
        public IActionResult Index()
        {
            
            return View(_dataAccess.GetObjectives());
        }

        [HttpPost]
        public IActionResult IndexObjective(Objective o)
        {
            if (o != null)
            {
                _dataAccess.AddObjective(o);
            }
            return RedirectToAction("Index"); 
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
            return Json(_dataAccess.GetObjectives());
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
            _dataAccess.DeleteObjective(id);
            return new EmptyResult();
        }

        [HttpPut]
        public IActionResult completeObjective(int id)
        {
            _dataAccess.CompleteObjective(id);
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

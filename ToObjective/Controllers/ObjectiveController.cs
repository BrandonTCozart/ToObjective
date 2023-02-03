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

        [HttpGet]
        public IActionResult getIndex()
        {
            IEnumerable<Objective> objectivesList = _db.Objectives;
            return Json(objectivesList);
        }

        [HttpPost]
        public JsonResult postIndex(Objective obj)
        {
            _db.Objectives.Add(obj);
            IEnumerable<Objective> objectivesList = _db.Objectives;
            return Json(objectivesList);
        }

        // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/ //




    }
}

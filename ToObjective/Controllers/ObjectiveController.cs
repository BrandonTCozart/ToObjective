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

        /*
        [HttpGet]
        public async Task<IActionResult> GetAllNotes()
        {
            return Ok(await _db.Objectives.ToListAsync());
        } 
        */



    }
}

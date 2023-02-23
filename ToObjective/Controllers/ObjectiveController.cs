using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToObjective.Data;
using ToObjective.Interfaces;
using ToObjective.Models;

namespace ToObjective.Controllers
{
    public class ObjectiveController : Controller
    {
        private readonly IObjectiveInterface _dataAccess;

        public ObjectiveController(IObjectiveInterface dataAccess)
        {
            this._dataAccess = dataAccess;
        }
        
        public async Task<IActionResult> Index()
        {
            var objectives = await _dataAccess.GetObjectivesAsync();
            return View(objectives);
        }

        public async Task<IActionResult> Details(int id)
        {
            var objective = await _dataAccess.GetObjectiveById(id);
            return View(objective);
        }

        [HttpGet]
        public async Task<IActionResult> LoadTableRows(string input) 
        {
            var objective =  await _dataAccess.GetByTitle(input);
            return PartialView("_TableToDo", objective);
        }

        public IActionResult addNew()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IndexObjective(Objective o) 
        {
            await _dataAccess.AddObjective(o);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> edit( int id)
        {
            var objective = await _dataAccess.GetObjectiveById(id);
            return View(objective);
        }

        [HttpPost]
        public IActionResult editObjective(Objective o)
        {
            _dataAccess.EditObjectives(o);
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> delete(int id) {
            _dataAccess.DeleteObjective(id);
            var objective = await _dataAccess.GetObjectivesAsync();
            return PartialView("_TableToDo", objective);
        }
        
        [HttpPut]
        public async Task<IActionResult> completeObjective(int id)
        {
            _dataAccess.CompleteObjective(id);
            var objective = await _dataAccess.GetObjectivesAsync();
            return PartialView("_TableToDo", objective);
        }
    }
}

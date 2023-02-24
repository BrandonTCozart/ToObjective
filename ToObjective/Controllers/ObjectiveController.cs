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

        public IActionResult AddNew()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IndexObjective(Objective o) 
        {
            await _dataAccess.AddObjective(o);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit( int id)
        {
            var objective = await _dataAccess.GetObjectiveById(id);
            return View(objective);
        }

        [HttpPost]
        public IActionResult EditObjective(Objective o)
        {
            _dataAccess.EditObjectives(o);
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id) {
            await _dataAccess.DeleteObjective(id);
            var objective = await _dataAccess.GetObjectivesAsync();
            return PartialView("_TableToDo", objective);
        }
        
        [HttpPut]
        public async Task<IActionResult> CompleteObjective(int id)
        {
            await _dataAccess.CompleteObjective(id);
            var objective = await _dataAccess.GetObjectivesAsync();
            return PartialView("_TableToDo", objective);
        }
    }
}

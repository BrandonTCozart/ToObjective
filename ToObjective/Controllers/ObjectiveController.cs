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
            var objective = await _dataAccess.GetByTitleDescription(input);
            return PartialView("_TableToDo", objective);
        }
        public async Task<IActionResult> AddNew(int id)
        {
            //if (id != -)
            //{
                var objective = await _dataAccess.GetObjectiveById(id);
                return View(objective);
            //}
            //return View();
        }

        [HttpPost]
        public async Task<IActionResult> IndexObjective(Objective obj)
        {
            await _dataAccess.AddObjective(obj);
            return RedirectToAction("Index");
        }



        [HttpPost]
        public IActionResult EditObjective(Objective obj)
        {
            _dataAccess.EditObjectives(obj);
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<object> Delete(int id)
        {
            await _dataAccess.DeleteObjective(id);
            var objective = await _dataAccess.GetObjectivesAsync();
            return 1;
        }

        [HttpPut]
        public async Task<object> CompleteObjective(int id)
        {
            await _dataAccess.CompleteObjective(id);
            var objective = await _dataAccess.GetObjectivesAsync();
            return null;
        }
    }
}

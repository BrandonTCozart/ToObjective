using Microsoft.AspNetCore.Mvc;
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
            var objectives = await _dataAccess.GetByTitleDescription();
            return View(objectives);
        }

        public IActionResult NotFound()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var objective = await _dataAccess.GetObjectiveById(id);
            if (objective == null)
            {
                return RedirectToAction("NotFound");
            }
            return View(objective);
        }

        [HttpGet]
        public async Task<IActionResult> LoadTableRows(string input)
        {
            var objective = await _dataAccess.GetByTitleDescription(input);
            return PartialView("_TableToDo", objective);
        }

        public async Task<IActionResult> AddEdit(int id)
        {
            var objective = await _dataAccess.GetObjectiveById(id);
            return View(objective);
        }

        [HttpPost]
        public async Task<IActionResult> IndexObjective(Objective obj)
        {
            await _dataAccess.AddObjective(obj);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<RedirectToActionResult> EditObjective(Objective obj)
        {
            await _dataAccess.EditObjectives(obj);
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<object> Delete(int id)
        {
            await _dataAccess.DeleteObjective(id);
            return Ok();
        }

        [HttpPut]
        public async Task<object> CompleteObjective(int id)
        {
            await _dataAccess.CompleteObjective(id);
            return Ok();
        }
    }
}

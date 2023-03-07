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
            try
            {
                return View(await _dataAccess.GetByTitleDescription());
            }
            catch (Exception ex)
            {
                return View();
            }
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
            try
            {
                return PartialView("_TableToDo", await _dataAccess.GetByTitleDescription(input));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<IActionResult> AddEditObjective(int id)
        {
            return View(await _dataAccess.GetObjectiveById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddObjective(Objective obj)
        {
            try
            {
                await _dataAccess.AddObjective(obj);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditObjective(Objective obj)
        {
            try
            {
                await _dataAccess.EditObjectives(obj);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _dataAccess.DeleteObjective(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> CompleteObjective(int id)
        {
            try
            {
                await _dataAccess.CompleteObjective(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

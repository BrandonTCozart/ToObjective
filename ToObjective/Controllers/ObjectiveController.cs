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
        
        public IActionResult Index()
        {
            return View(_dataAccess.GetObjectives());
        }

        public IActionResult addNew()
        {
            return View();
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
        
        public IActionResult edit( int id)
        {
            return View(_dataAccess.GetObjectiveById(id));
        }

        [HttpPost]
        public IActionResult editObjective(Objective o)
        {
            _dataAccess.editObjectives(o);
            return RedirectToAction("Index");
        }

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
    }
}

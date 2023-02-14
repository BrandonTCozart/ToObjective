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
            return new EmptyResult(); 
        }
        

        
        public IActionResult addNew()
        {
            return View();
        }
        public IActionResult edit( int id)
        {
            return View(_dataAccess.GetObjectiveById(id));
        }

        /*
        [HttpGet]
        public IActionResult getIndex()
        {
            return Json(_dataAccess.GetObjectives());
        }
        */

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

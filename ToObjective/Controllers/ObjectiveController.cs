using Microsoft.AspNetCore.Mvc;
using ToObjective.Interfaces;
using ToObjective.Models;
//using System.Web.Http;
namespace ToObjective.Controllers;

[ApiController]
[Route("api/Controller")]
//public class ObjectiveController : Controller
public class ObjectiveController : ControllerBase

{
    [HttpGet]
    public String getObjectives()
    {
        return "information";
        //return View(await _dataAccess.GetByTitleDescription());
    }
    /*
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
    public async Task<IActionResult> AddOrEditObjective(Objective obj)
    {
        try
        {
            if (obj.CompletedDate == null)
            {
                await _dataAccess.CreateOrChangeObjective(obj);
            }
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
    */
}


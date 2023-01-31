using Microsoft.AspNetCore.Mvc;

namespace ToObjective.Controllers
{
    public class ObjectiveController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

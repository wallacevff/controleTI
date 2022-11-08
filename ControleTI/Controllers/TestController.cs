using Microsoft.AspNetCore.Mvc;

namespace ControleTI.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View("/Views/TestsViews/Index.cshtml");
        }
    }
}

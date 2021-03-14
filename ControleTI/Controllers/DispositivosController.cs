using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleTI.Controllers
{
    public class DispositivosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

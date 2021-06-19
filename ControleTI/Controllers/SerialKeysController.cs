using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleTI.Services;

namespace ControleTI.Controllers
{
    public class SerialKeysController : Controller
    {
        private readonly SerialKeyService _serialKeyService;
        private readonly SoftwareService _softwareService;

        public SerialKeysController(SerialKeyService serialKeyService, SoftwareService softwareService)
        {
            _serialKeyService = serialKeyService;
            _softwareService = softwareService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _serialKeyService.FindAllAsync());
        }
    }
}

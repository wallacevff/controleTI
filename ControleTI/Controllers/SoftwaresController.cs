using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleTI.Services;
using ControleTI.Models;

namespace ControleTI.Controllers
{
    public class SoftwaresController : Controller
    {
        private readonly SerialKeyService _serialKeysService;
        private readonly SoftwareService _softwareService;

        public SoftwaresController(SerialKeyService serialKeysService, SoftwareService softwareService)
        {
            _serialKeysService = serialKeysService;
            _softwareService = softwareService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _softwareService.FindAllAsync());
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(Software software)
        {
            await _softwareService.CriarAssync(software);
            return RedirectToAction(nameof(Index));
        }

    }
}

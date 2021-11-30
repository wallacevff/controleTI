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

        public async Task<IActionResult> Editar(int? id)
        {

            var software = await _softwareService.FindByIdAsync(id.Value);
            return View(software);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int? id, Software software)
        {
            if (id != software.Id)
            {
                return NotFound();
            }
            await _softwareService.UpdateAsync(software);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Excluir(int? id)
        {
            var setor = await _softwareService.FindByIdAsync(id.Value);
            return View(setor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Excluir(Software software)
        {
            await _softwareService.Delete(software);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detalhes(int? id)
        {
            var software = await _softwareService.FindByIdAsync(id.Value);
            return View(software);
        }


        public async Task<IActionResult> PesquisarJSON(string nomeSoftware)
        {
            List<Software> softwares;
            if (string.IsNullOrEmpty(nomeSoftware))
            {
                softwares = await _softwareService.FindAllAsync();
                return Json(softwares.Select(o => new { o.Id, o.Nome }));
            }
            softwares = await _softwareService.FindAssync(nomeSoftware);
            return Json(softwares.Select(o => new { o.Id, o.Nome}));
        }

    }
}

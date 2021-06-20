using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleTI.Services;
using ControleTI.Models;
using ControleTI.Models.ViewModels;
using ControleTI.Data;
using Microsoft.EntityFrameworkCore;


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

        public async Task<IActionResult> Criar()
        {
            var softwares = await _softwareService.FindAllAsync();
            var viewModel = new ControleTI.Models.ViewModels.SerialKeyViewModel
            {
                Softwares = softwares
            };
         
            return View(viewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Criar(SerialKey serialKey)
        {
            serialKey.RestantesInicial();
            await _serialKeyService.CriarAssync(serialKey);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Editar(int id)
        {
            var serialKey = await _serialKeyService.FindByIdAsync(id);
            SerialKeyViewModel serialKeyViewModel = new SerialKeyViewModel()
            {
                SerialKey = serialKey,
                Softwares = await _softwareService.FindAllAsync()
            };
            return View(serialKeyViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, SerialKey serialKey)
        {
           
            if (id != serialKey.Id)
            {
                return NotFound();
            }
           
            serialKey.RestantesAtualizar();
            await _serialKeyService.UpdateAsync(serialKey);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Excluir(int id)
        {
            SerialKey serialKey = await _serialKeyService.FindByIdAsync(id);
            return View(serialKey);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Excluir(SerialKey serialKey)
        {
            await _serialKeyService.Delete(serialKey);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detalhes(int id)
        {
            var serialKey = await _serialKeyService.FindByIdAsync(id);
         
            return View(serialKey);
        }

    }
}

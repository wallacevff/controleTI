using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleTI;
using ControleTI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ControleTI.Services;

namespace ControleTI.Controllers
{
    public class SetoresController : Controller
    {
        private readonly SetorService _setorService;

        public SetoresController(SetorService setorService)
        {
            _setorService = setorService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _setorService.FindAllAsync());
        }

        public async Task<IActionResult> Editar(int? id)
        {
          
            var setor = await _setorService.FindByIdAsync(id.Value);
            return View(setor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int? id, Setor setor)
        {
            if(id != setor.Id)
            {
                return NotFound();
            }
            await _setorService.UpdateAsync(setor);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(Setor setor)
        {
            await _setorService.CriarAssync(setor);
            return RedirectToAction(nameof(Index));
        }

        public async Task <IActionResult> Excluir(int? id)
        {
            var setor = await _setorService.FindByIdAsync(id.Value);
            return View(setor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Excluir(Setor setor)
        {
            await _setorService.Delete(setor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detalhes(int? id)
        {
            var setor = await _setorService.FindByIdAsync(id.Value);
            return View(setor);
        }

    }
}

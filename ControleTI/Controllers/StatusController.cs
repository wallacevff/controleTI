using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleTI.Services;
using ControleTI.Models;

namespace ControleTI.Controllers
{
    public class StatusController : Controller
    {
        private readonly StatusService _statusService;

        public StatusController(StatusService statusService)
        {
            _statusService = statusService;
   
        }
        public async Task<IActionResult> Index()
        {
            return View(await _statusService.Listar());
        }

        public async Task<IActionResult> Editar(int? id)
        {

            var status = await _statusService.FindByIdAsync(id.Value);
            return View(status);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int? id, Status status)
        {
            if (id != status.StatusId)
            {
                return NotFound();
            }
            await _statusService.Atualizar(status);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(Status status)
        {
            await _statusService.Cadastrar(status);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Excluir(int? id)
        {
            Status status = await _statusService.FindByIdAsync(id.Value);
            return View(status);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Excluir(Status status)
        {
            await _statusService.DeletarAsync(status);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detalhes(int? id)
        {
            Status status = await _statusService.FindByIdAsync(id.Value);
            return View(status);
        }
    }
}

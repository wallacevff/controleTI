using Microsoft.AspNetCore.Mvc;
using ControleTI.Models;
using ControleTI.Services;
using System.Threading.Tasks;
using ControleTI.Models.ViewModels;
using System.Collections.Generic;
using System;

namespace ControleTI.Controllers
{
    public class EmpresaParceiraController : Controller
    {
        private readonly EmpresaParceiraService _empresaParceiraService;
        public EmpresaParceiraController(EmpresaParceiraService empresaParceiraService)
        {
            _empresaParceiraService = empresaParceiraService;
        }

        public async Task<IActionResult> Index()
        {
            EmpresaParceiraViewModel empresaParceiraViewModel = new EmpresaParceiraViewModel(await _empresaParceiraService.ListEmpresaParceira());
            return View(empresaParceiraViewModel);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(EmpresaParceira empresaParceira)
        {
            EmpresaParceira emp = await _empresaParceiraService.AddEmpresaParceira(empresaParceira);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Create(EmpresaParceira empresaParceira)
        {
            EmpresaParceira emp = await _empresaParceiraService.AddEmpresaParceira(empresaParceira);
            //Console.WriteLine("Alou");
            return Json(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task Delete(int id, EmpresaParceira empresaParceira)
        {
            empresaParceira = await _empresaParceiraService.FindEmpresaParceiraById(id);
            await _empresaParceiraService.DeleteEmpresaParceira(empresaParceira);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using ControleTI.Models;
using ControleTI.Services;
using System.Threading.Tasks;
using ControleTI.Models.ViewModels;
using System.Collections.Generic;
using System;

namespace ControleTI.Controllers
{
    public class ContratoController : Controller
    {
        private readonly EmpresaParceiraService _empresaParceiraService;
        private readonly ContratoService _contratoService;
        private readonly UsuarioService _usuarioService;

        public ContratoController(EmpresaParceiraService empresaParceiraService, ContratoService contratoService, UsuarioService usuarioService)
        {
            _empresaParceiraService = empresaParceiraService;
            _contratoService = contratoService;
            _usuarioService = usuarioService;
        }

        public async Task<IActionResult> Index()
        {
            ContratoViewModel contratoViewModel = new ContratoViewModel(
                await _empresaParceiraService.ListEmpresaParceira(),
                await _contratoService.ListContrato(),
                await _usuarioService.FindAllAsync()
                );

            return View(contratoViewModel);
        }

        public async Task<IActionResult> Criar()
        {
            ContratoViewModel contratoViewModel = new ContratoViewModel(
                   await _empresaParceiraService.ListEmpresaParceira(),
                   await _usuarioService.FindAllAsync()
                );
            return View(contratoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(Contrato contrato)
        {
            Contrato con = await _contratoService.AddContrato(contrato);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Create(Contrato contrato)
        {
            Contrato c = await _contratoService.AddContrato(contrato);
            //Console.WriteLine("Alou");
            return Json(c);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task Delete(int id, Contrato contrato)
        {
            contrato = await _contratoService.FindContratoById(id);
            await _contratoService.DeleteContrato(contrato);
        }

      
        
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return View();
            }
            ContratoViewModel contratoViewModel = new ContratoViewModel(
                    await _empresaParceiraService.ListEmpresaParceira(),
                    await _contratoService.FindContratoById(id.Value),
                    await _usuarioService.FindAllAsync()
                );
            return View(contratoViewModel);

        }
    }
}

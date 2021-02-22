using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleTI.Services;
using ControleTI.Models.VewModels;
using ControleTI.Models;
using ControleTI.Data;
using Microsoft.EntityFrameworkCore;


namespace ControleTI.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly UsuarioService _usuarioService;
        private readonly SetorService _setorService;
        private readonly ControleTIContext _filialContext;
        public UsuariosController(UsuarioService usuarioService, SetorService setorService, ControleTIContext filialContext)
        {
            _usuarioService = usuarioService;
            _setorService = setorService;
            _filialContext = filialContext; 
        }

        public async Task<IActionResult> Index()
        {
            return View( await _usuarioService.FindAllAsync());
        }

        public async Task<IActionResult> Criar()
        {
            var setores = await _setorService.FindAllAsync();
            var filiais = await _filialContext.Filial.ToListAsync();
            var viewModel = new UsuarioViewModel { Setores = setores,
                                                   Filiais = filiais};
            return View(viewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Criar(Usuario usuario)
        {
            await _usuarioService.Insert(usuario);
            return RedirectToAction(nameof(Index));
        }

         public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View(await _usuarioService.FindByIdAsync(id.Value));
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var setores = await _setorService.FindAllAsync();
            var filiais = await _filialContext.Filial.ToListAsync();
            var usuario = await _usuarioService.FindByIdAsync(id.Value);
            var viewModel = new UsuarioViewModel { Setores = setores,
                                                   Filiais = filiais,
                                                   Usuario = usuario};

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Usuario usuario)
        {
            await _usuarioService.UpdateAsync(usuario);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Excluir(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var usuario = await _usuarioService.FindByIdAsync(id.Value);
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Excluir(Usuario usuario)
        {
            await _usuarioService.Delete(usuario);
            return RedirectToAction(nameof(Index));
        }
    }
}

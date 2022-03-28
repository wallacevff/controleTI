using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleTI.Services;
using ControleTI.Models.ViewModels;
using ControleTI.Models;
using ControleTI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ControleTI.Controllers
{
    [Authorize]
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
            var viewModel = new UsuarioViewModel
            {
                Setores = await _setorService.FindAllAsync(),
                Filiais = await _filialContext.Filial.ToListAsync(),
                Usuarios = await _usuarioService.FindAllAsync()
            };
            return View(viewModel);
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

        public async Task<IActionResult> PesquisarJSON(string nomeUsuario, string nomeCompleto, int setor, int filial)
        {
            List<Usuario> usuarios; usuarios = null;
            if (!string.IsNullOrEmpty(nomeUsuario))
            {
                //usuarios = await _usuarioService.FindAllAsync();
                usuarios = await _usuarioService.FindByNameAsync(nomeUsuario);
                // return Json(usuarios.Select(o => new { o.Id, o.NomeUsu, o.NomeCompleto, Setor = o.Setor.Nome, Filial = o.Filial.Nome}));
            }
            if (!string.IsNullOrEmpty(nomeCompleto))
            {
                if(usuarios == null)
                {
                    usuarios = await _usuarioService.PesquisarNomeCompleto(nomeCompleto);
                }
                else
                {
                    usuarios = usuarios.Where(obj => obj.NomeCompleto.ToLower().Contains(nomeCompleto.ToLower())).ToList();
                }
                
            }
            if (setor != 0)
            {
                if (usuarios == null)
                {
                    usuarios = await _usuarioService.PesquisarSetor(setor);
                }
                else
                {
                    usuarios = usuarios.Where(obj => obj.SetorId == setor).ToList();
                }
            }
            if (filial != 0)
            {
                if (usuarios == null)
                {
                    usuarios = await _usuarioService.PesquisarFilial(filial);
                }
                else
                {
                    usuarios = usuarios.Where(obj => obj.FilialId == filial).ToList();
                }
            }
            if (usuarios == null)
            {
                usuarios = await _usuarioService.FindAllAsync();
            }
            
            return Json(usuarios.Select(o => new { o.Id, o.NomeUsu, o.NomeCompleto, Setor = o.Setor.Nome, Filial =  o.Filial.Nome }));
        }
    }
}

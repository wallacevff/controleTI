using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ControleTI.Services;
using ControleTI.Models;
using ControleTI.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace ControleTI.Controllers
{
    public class DispositivosController : Controller
    {
        private readonly DispositivoService _dispositivoService;
        private readonly UsuarioService _usuarioService;
        private readonly TipoDispositivoService _tipoDispositivoService;
        private readonly SoftwareService _softwareService;
        private readonly SerialKeyService _serialKeyService;
        private readonly StatusService _statusService;

        public DispositivosController(DispositivoService dispositivoService, UsuarioService usuarioService,
            TipoDispositivoService tipoDispositivoService, SoftwareService softwareService, SerialKeyService serialKeyService,
            StatusService statusService)
        {
            _dispositivoService = dispositivoService;
            _usuarioService = usuarioService;
            _tipoDispositivoService = tipoDispositivoService;
            _softwareService = softwareService;
            _serialKeyService = serialKeyService;
            _statusService = statusService;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            List<Dispositivo> dispositivos = await _dispositivoService.FindAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                dispositivos = await _dispositivoService.PesquisaNome(searchString);
            }

            return View(dispositivos);
        }


        public async Task<IActionResult> Criar()
        {
            var tiposDispositivos = await _tipoDispositivoService.FindAllAsync();
            var usarios = await _usuarioService.FindAllAsync();
            List<Status> status = await _statusService.Listar();
            DispositivoViewModel dispositivoViewModel = new DispositivoViewModel
            {
                TiposDispositivos = tiposDispositivos,
                Usuarios = usarios,
                Status = status
            };
            return View(dispositivoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(Dispositivo dispositivo)
        {
            await _dispositivoService.CriarAssync(dispositivo);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Editar(int? id)
        {
            DispositivoViewModel dispositivoViewModel = new DispositivoViewModel()
            {
                TiposDispositivos = await _tipoDispositivoService.FindAllAsync(),
                Usuarios = await _usuarioService.FindAllAsync(),
                Dispositivo = await _dispositivoService.FindByIdAsync(id.Value),
                Status = await _statusService.Listar()
            };            
            return View(dispositivoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int? id, Dispositivo dispositivo)
        {
            if (id != dispositivo.Id)
            {
                return NotFound();
            }
            await _dispositivoService.UpdateAsync(dispositivo);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Excluir(int? id)
        {
            var dispositivo = await _dispositivoService.FindByIdAsync(id.Value);
            return View(dispositivo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Excluir(Dispositivo dispositivo)
        {
            await _dispositivoService.Delete(dispositivo);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detalhes(int? id)
        {
            var dispositivo = await _dispositivoService.FindByIdAsync(id.Value);
            return View(dispositivo);
        }

        public async Task<IActionResult> Pesquisar(string searchString)
        {
            IEnumerable<Dispositivo> dispositivos;
            if (!string.IsNullOrEmpty(searchString))
            {
                dispositivos = await _dispositivoService.PesquisaNome(searchString);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
            return View("/Views/Dispositivos/Index.cshtml", dispositivos);
        }

        public async Task<IActionResult> PesquisarUsuario(string searchString)
        {
            IEnumerable<Dispositivo> dispositivos;
            if (!string.IsNullOrEmpty(searchString))
            {
                dispositivos = await _dispositivoService.PesquisaUsuario(searchString);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
            return View("/Views/Dispositivos/Index.cshtml", dispositivos);
        }
    }
}

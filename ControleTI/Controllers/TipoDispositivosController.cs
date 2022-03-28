using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ControleTI.Services;
using ControleTI.Models;
using Microsoft.AspNetCore.Authorization;

namespace ControleTI.Controllers
{
    [Authorize]
    public class TipoDispositivosController : Controller
    {
        private readonly TipoDispositivoService _tipoDispositivoService;

        public TipoDispositivosController(TipoDispositivoService tipoDispositivoService)
        {
            _tipoDispositivoService = tipoDispositivoService;
   
        }
        public async Task<IActionResult> Index()
        {
            return View(await _tipoDispositivoService.FindAllAsync());
        }

        public async Task<IActionResult> Editar(int? id)
        {

            var setor = await _tipoDispositivoService.FindByIdAsync(id.Value);
            return View(setor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int? id, TipoDispositivo tipoDispositivo)
        {
            if (id != tipoDispositivo.Id)
            {
                return NotFound();
            }
            await _tipoDispositivoService.UpdateAsync(tipoDispositivo);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(TipoDispositivo tipoDispositivo)
        {
            await _tipoDispositivoService.CriarAssync(tipoDispositivo);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Excluir(int? id)
        {
            TipoDispositivo tipoDispositivo = await _tipoDispositivoService.FindByIdAsync(id.Value);
            return View(tipoDispositivo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Excluir(TipoDispositivo tipoDispositivo)
        {
            await _tipoDispositivoService.Delete(tipoDispositivo);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detalhes(int? id)
        {
            TipoDispositivo tipoDispositivo = await _tipoDispositivoService.FindByIdAsync(id.Value);
            return View(tipoDispositivo);
        }
    }
}

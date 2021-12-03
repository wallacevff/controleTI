using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleTI.Services;
using ControleTI.Models;
using ControleTI.Models.ViewModels;


/* */
namespace ControleTI.Controllers
{
    public class SerialKeysController : Controller
    {
        private readonly SerialKeyService _serialKeyService;
        private readonly SoftwareService _softwareService;
        private readonly DispositivoSoftwareService _dispositivoSoftwareService;

        public SerialKeysController(SerialKeyService serialKeyService, SoftwareService softwareService, DispositivoSoftwareService dispositivoSoftwareService)
        {
            _serialKeyService = serialKeyService;
            _softwareService = softwareService;
            _dispositivoSoftwareService = dispositivoSoftwareService;
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
            List<DispositivoSoftware> dispositivoSoftwares = await _dispositivoSoftwareService.FindByKeyIdAsync(serialKey.Id);

            if (!(dispositivoSoftwares == null))
            {
                foreach (DispositivoSoftware ds in dispositivoSoftwares)
                {
                    ds.SerialKeyId = null;
                    await _dispositivoSoftwareService.UpdateAsync(ds);
                }
            }

            await _serialKeyService.Delete(serialKey);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detalhes(int id)
        {
            var serialKey = await _serialKeyService.FindByIdAsync(id);

            return View(serialKey);
        }


        public async Task<IActionResult> PesquisarJSON(string serialKey, string software, bool? restantes)
        {
            List<SerialKey> serialKeys = await _serialKeyService.Pesquisar(serialKey, software, restantes);
            return Json(serialKeys.Select(obj => new { obj.Id, nomeSoftware = obj.Software.Nome, obj.Key, obj.Quantidade, obj.Utilizadas, obj.Restantes }));
        }


        //Protótipos Pesquisa _-----------------------------------------------------------


        //public async Task<IActionResult> Pesquisar(string searchString)
        //{
        //    IEnumerable<SerialKey> serialKeys;
        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        serialKeys = await _serialKeyService.PesquisaNome(searchString);
        //    }
        //    else
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View("~/Views/SerialKeys/Index.cshtml", serialKeys);
        //}

        //public async Task<IActionResult> PesquisarSoftware(string searchString)
        //{
        //    IEnumerable<SerialKey> serialKeys;
        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        serialKeys = await _serialKeyService.PesquisaSoftware(searchString);
        //    }
        //    else
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View("~/Views/SerialKeys/Index.cshtml", serialKeys);
        //}
    }
}

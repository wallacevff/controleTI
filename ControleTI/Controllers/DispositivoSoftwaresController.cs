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
    public class DispositivoSoftwaresController : Controller
    {
        private readonly DispositivoService _dispositivoService;
        private readonly SerialKeyService _serialKeyService;
        private readonly SoftwareService _softwareService;
        private readonly DispositivoSoftwareService _dispositivoSoftwareService;

        public DispositivoSoftwaresController(SerialKeyService serialKeyService, SoftwareService softwareService, 
            DispositivoSoftwareService dispositivoSoftwareService, DispositivoService dispositivoService)
        {
            _dispositivoService = dispositivoService;
            _serialKeyService = serialKeyService;
            _softwareService = softwareService;
            _dispositivoSoftwareService = dispositivoSoftwareService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _dispositivoSoftwareService.FindAllAsync());
        }

        public async Task<IActionResult> CadastrarSoftware(int dispositivoId)
        {
            Dispositivo dispositivo = await _dispositivoService.FindByIdAsync(dispositivoId);
            List<Software> softwares = await _softwareService.FindAllAsync();
            List<DispositivoSoftware> dispositivoSoftwares = await _dispositivoSoftwareService.FindAllByIdAsync(dispositivoId);
            List<Software> softwaresDoDispositivo = dispositivoSoftwares.Select(obj => obj.Software).ToList();
            List<Software> softwaresExibicao = softwares.Except(softwaresDoDispositivo).ToList();
            DispositivoSoftwareViewModel viewModel = new ControleTI.Models.ViewModels.DispositivoSoftwareViewModel
            {
                Dispositivo = dispositivo,
                Softwares = softwaresExibicao
            };
         
            return View(viewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CadastrarSoftware(DispositivoSoftware dispositivoSoftware)
        {
            
            await _dispositivoSoftwareService.CriarAssync(dispositivoSoftware);
            return RedirectToAction("Detalhes", "Dispositivos", new { id = dispositivoSoftware.DispositivoId });
        }

        public async Task<IActionResult> CadastrarSerialKey(int id)
        {
            DispositivoSoftware dispositivoSoftware = await _dispositivoSoftwareService.FindByIdAsync(id);

            DispositivoSoftwareViewModel viewModel = new ControleTI.Models.ViewModels.DispositivoSoftwareViewModel
            {
                DispositivoSoftware = dispositivoSoftware,
                Dispositivo = await _dispositivoService.FindByIdAsync(dispositivoSoftware.DispositivoId),
                Software = await _softwareService.FindByIdAsync(dispositivoSoftware.SoftwareId),
                SerialKeys = await _serialKeyService.FindAllByIdAsync(dispositivoSoftware.SoftwareId)
            };

            return View(viewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CadastrarSerialKey(int id, DispositivoSoftware dispositivoSoftware)
        {

            if (id != dispositivoSoftware.Id)
            {
                return NotFound();
            }
            SerialKey serialKey = await _serialKeyService.FindByIdAsync(dispositivoSoftware.SerialKeyId.Value);
            serialKey.UtilizadasIncrementar();
            await _serialKeyService.UpdateAsync(serialKey);
            await _dispositivoSoftwareService.UpdateAsync(dispositivoSoftware);
            return RedirectToAction("Detalhes", "Dispositivos", new { id = dispositivoSoftware.DispositivoId });
        }








        public async Task<IActionResult> CadastrarIdInstalacao(int id)
        {
            DispositivoSoftware dispositivoSoftware = await _dispositivoSoftwareService.FindByIdAsync(id);

            DispositivoSoftwareViewModel viewModel = new ControleTI.Models.ViewModels.DispositivoSoftwareViewModel
            {
                DispositivoSoftware = dispositivoSoftware,
                Dispositivo = await _dispositivoService.FindByIdAsync(dispositivoSoftware.DispositivoId),
                Software = await _softwareService.FindByIdAsync(dispositivoSoftware.SoftwareId),
                SerialKey = await _serialKeyService.FindByIdAsync(dispositivoSoftware.SerialKeyId.Value)
            };

            return View(viewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CadastrarIdInstalacao(int id, DispositivoSoftware dispositivoSoftware)
        {

            if (id != dispositivoSoftware.Id)
            {
                return NotFound();
            }
            await _dispositivoSoftwareService.UpdateAsync(dispositivoSoftware);
            return RedirectToAction("Detalhes", "Dispositivos", new { id = dispositivoSoftware.DispositivoId });
        }




        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task Apagar(int id)
        {
            DispositivoSoftware dispositivoSoftware = await _dispositivoSoftwareService.FindByIdAsync(id);
            if (dispositivoSoftware.SerialKeyId != null)
            {
                SerialKey serialKey = await _serialKeyService.FindByIdAsync(dispositivoSoftware.SerialKeyId.Value);
                serialKey.UtilizadasDecrementar();
                await _serialKeyService.UpdateAsync(serialKey);
            }
            
            await _dispositivoSoftwareService.Delete(dispositivoSoftware);
            
           // return RedirectToAction("Detalhes", "Dispositivos", new { id = dispositivoSoftware.DispositivoId });
        }


        public async Task<IActionResult> Detalhes(int id)
        {
            var serialKey = await _dispositivoSoftwareService.FindByIdAsync(id);
         
            return View(serialKey);
        }

    }
}

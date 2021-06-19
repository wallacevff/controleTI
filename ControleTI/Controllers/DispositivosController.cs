using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleTI.Services;

namespace ControleTI.Controllers
{
    public class DispositivosController : Controller
    {
        private readonly DispositivoService _dispositivoService;
        private readonly TipoDispositivoService _tipoDispositivoService;
        private readonly SoftwareService _softwareService;
        private readonly SerialKeyService _serialKeyService;

        public DispositivosController(DispositivoService dispositivoService, TipoDispositivoService tipoDispositivoService, SoftwareService softwareService, SerialKeyService serialKeyService)
        {
            _dispositivoService = dispositivoService;
            _tipoDispositivoService = tipoDispositivoService;
            _softwareService = softwareService;
            _serialKeyService = serialKeyService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _dispositivoService.FindAllAsync());
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleTI.Services;

namespace ControleTI.Controllers
{
    public class TipoDispositivoController : Controller
    {
        private readonly TipoDispositivoService _tipoDispositivoService;
        private readonly DispositivoService _dispositivoService;

        public TipoDispositivoController(TipoDispositivoService tipoDispositivoService, DispositivoService dispositivoService)
        {
            _tipoDispositivoService = tipoDispositivoService;
            _dispositivoService = dispositivoService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _tipoDispositivoService.FindAllAsync());
        }
    }
}

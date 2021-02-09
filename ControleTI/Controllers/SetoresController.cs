using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleTI;
using ControleTI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ControleTI.Services;

namespace ControleTI.Controllers
{
    public class SetoresController : Controller
    {
        private readonly SetorService _setorService;

        public SetoresController(SetorService setorService)
        {
            _setorService = setorService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _setorService.FindAllAsync());
        }

        public async Task<IActionResult> Editar(int? id)
        {
          
            var setor = await _setorService.FindById(id.Value);
            return View(setor);
        }
    }
}

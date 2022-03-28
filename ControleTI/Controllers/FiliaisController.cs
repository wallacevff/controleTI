using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControleTI.Data;
using ControleTI.Models;
using Microsoft.AspNetCore.Authorization;

namespace ControleTI.Controllers
{
    [Authorize]
    public class FiliaisController : Controller
    {
        private readonly ControleTIContext _context;

        public FiliaisController(ControleTIContext context)
        {
            _context = context;
        }

        // GET: Filiais
        public async Task<IActionResult> Index()
        {
            return View(await _context.Filial.ToListAsync());
        }

        // GET: Filiais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filial = await _context.Filial
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filial == null)
            {
                return NotFound();
            }

            return View(filial);
        }

        // GET: Filiais/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Filiais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Filial filial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filial);
        }

        // GET: Filiais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filial = await _context.Filial.FindAsync(id);
            if (filial == null)
            {
                return NotFound();
            }
            return View(filial);
        }

        // POST: Filiais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Filial filial)
        {
            if (id != filial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilialExists(filial.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(filial);
        }

        // GET: Filiais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filial = await _context.Filial
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filial == null)
            {
                return NotFound();
            }

            return View(filial);
        }

        // POST: Filiais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filial = await _context.Filial.FindAsync(id);
            _context.Filial.Remove(filial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilialExists(int id)
        {
            return _context.Filial.Any(e => e.Id == id);
        }

        public async Task<IActionResult> PesquisarJSON(string nomeFilial)
        {
            List<Filial> filiais = null;
            if (string.IsNullOrEmpty(nomeFilial))
            {
                filiais = await _context.Filial.ToListAsync();
                return Json(filiais);
            }
            filiais = await _context.Filial
                .Where(obj => obj.Nome
                        .ToLower()
                        .Contains(nomeFilial
                            .ToLower()
                            )
                        )
                .ToListAsync();
            return Json(filiais);
        }
    }
}

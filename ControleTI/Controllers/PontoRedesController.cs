using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleTI.Data;
using ControleTI.Models;

namespace ControleTI.Controllers
{
    public class PontoRedesController : Controller
    {
        private readonly ControleTIContext _context;

        public PontoRedesController(ControleTIContext context)
        {
            _context = context;
        }

        // GET: PontoRedes
        public async Task<IActionResult> Index()
        {
            var controleTIContext = _context.PontoRede.Include(p => p.Filial).Include(p => p.Setor);
            return View(await controleTIContext.ToListAsync());
        }

        // GET: PontoRedes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pontoRede = await _context.PontoRede
                .Include(p => p.Filial)
                .Include(p => p.Setor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pontoRede == null)
            {
                return NotFound();
            }

            return View(pontoRede);
        }

        // GET: PontoRedes/Create
        public IActionResult Create()
        {
            ViewData["FilialId"] = new SelectList(_context.Filial, "Id", "Id");
            ViewData["SetorId"] = new SelectList(_context.Setor, "Id", "Id");
            return View();
        }

        // POST: PontoRedes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FilialId,SetorId,Funcao")] PontoRede pontoRede)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pontoRede);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilialId"] = new SelectList(_context.Filial, "Id", "Id", pontoRede.FilialId);
            ViewData["SetorId"] = new SelectList(_context.Setor, "Id", "Id", pontoRede.SetorId);
            return View(pontoRede);
        }

        // GET: PontoRedes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pontoRede = await _context.PontoRede.FindAsync(id);
            if (pontoRede == null)
            {
                return NotFound();
            }
            ViewData["FilialId"] = new SelectList(_context.Filial, "Id", "Id", pontoRede.FilialId);
            ViewData["SetorId"] = new SelectList(_context.Setor, "Id", "Id", pontoRede.SetorId);
            return View(pontoRede);
        }

        // POST: PontoRedes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FilialId,SetorId,Funcao")] PontoRede pontoRede)
        {
            if (id != pontoRede.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pontoRede);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PontoRedeExists(pontoRede.Id))
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
            ViewData["FilialId"] = new SelectList(_context.Filial, "Id", "Id", pontoRede.FilialId);
            ViewData["SetorId"] = new SelectList(_context.Setor, "Id", "Id", pontoRede.SetorId);
            return View(pontoRede);
        }

        // GET: PontoRedes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pontoRede = await _context.PontoRede
                .Include(p => p.Filial)
                .Include(p => p.Setor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pontoRede == null)
            {
                return NotFound();
            }

            return View(pontoRede);
        }

        // POST: PontoRedes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pontoRede = await _context.PontoRede.FindAsync(id);
            _context.PontoRede.Remove(pontoRede);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PontoRedeExists(int id)
        {
            return _context.PontoRede.Any(e => e.Id == id);
        }
    }
}

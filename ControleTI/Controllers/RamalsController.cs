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
    public class RamalsController : Controller
    {
        private readonly ControleTIContext _context;

        public RamalsController(ControleTIContext context)
        {
            _context = context;
        }

        // GET: Ramals
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ramal.ToListAsync());
        }

        // GET: Ramals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ramal = await _context.Ramal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ramal == null)
            {
                return NotFound();
            }

            return View(ramal);
        }

        // GET: Ramals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ramals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PontoId,VoicePanelPonto,RamalNro")] Ramal ramal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ramal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ramal);
        }

        // GET: Ramals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ramal = await _context.Ramal.FindAsync(id);
            if (ramal == null)
            {
                return NotFound();
            }
            return View(ramal);
        }

        // POST: Ramals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PontoId,VoicePanelPonto,RamalNro")] Ramal ramal)
        {
            if (id != ramal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ramal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RamalExists(ramal.Id))
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
            return View(ramal);
        }

        // GET: Ramals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ramal = await _context.Ramal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ramal == null)
            {
                return NotFound();
            }

            return View(ramal);
        }

        // POST: Ramals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ramal = await _context.Ramal.FindAsync(id);
            _context.Ramal.Remove(ramal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RamalExists(int id)
        {
            return _context.Ramal.Any(e => e.Id == id);
        }
    }
}

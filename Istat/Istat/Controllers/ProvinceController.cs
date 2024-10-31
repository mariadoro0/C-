using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Istat.Models;

namespace Istat.Controllers
{
    public class ProvinceController : Controller
    {
        private readonly Istat2015Context _context;

        public ProvinceController(Istat2015Context context)
        {
            _context = context;
        }

        // GET: Province
        public async Task<IActionResult> Index()
        {
            var istat2015Context = _context.Province.Include(p => p.IdRegioneNavigation).Include(p => p.Comunes);
            return View(await istat2015Context.ToListAsync());
        }

        // GET: Province/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provincia = await _context.Province
                .Include(p => p.IdRegioneNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (provincia == null)
            {
                return NotFound();
            }

            return View(provincia);
        }

        // GET: Province/Create
        public IActionResult Create()
        {
            ViewData["IdRegione"] = new SelectList(_context.Regioni, "Id", "Id");
            return View();
        }

        // POST: Province/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Denominazione,Sigla,CodiceCittaMetropolitana,IdRegione")] Provincia provincia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(provincia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRegione"] = new SelectList(_context.Regioni, "Id", "Id", provincia.IdRegione);
            return View(provincia);
        }

        // GET: Province/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provincia = await _context.Province.FindAsync(id);
            if (provincia == null)
            {
                return NotFound();
            }
            ViewData["IdRegione"] = new SelectList(_context.Regioni, "Id", "Id", provincia.IdRegione);
            return View(provincia);
        }

        // POST: Province/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Denominazione,Sigla,CodiceCittaMetropolitana,IdRegione")] Provincia provincia)
        {
            if (id != provincia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(provincia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProvinciaExists(provincia.Id))
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
            ViewData["IdRegione"] = new SelectList(_context.Regioni, "Id", "Id", provincia.IdRegione);
            return View(provincia);
        }

        // GET: Province/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provincia = await _context.Province
                .Include(p => p.IdRegioneNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (provincia == null)
            {
                return NotFound();
            }

            return View(provincia);
        }

        // POST: Province/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var provincia = await _context.Province.FindAsync(id);
            if (provincia != null)
            {
                _context.Province.Remove(provincia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProvinciaExists(int id)
        {
            return _context.Province.Any(e => e.Id == id);
        }
    }
}

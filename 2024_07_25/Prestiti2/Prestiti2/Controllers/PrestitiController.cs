using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrestitiBiblio.Models;

namespace Prestiti2.Controllers
{
    public class PrestitiController : Controller
    {
        private readonly PrestitiBibliotecaContext _context;

        public PrestitiController(PrestitiBibliotecaContext context)
        {
            _context = context;
        }

        // GET: Prestiti
        public async Task<IActionResult> Index()
        {
            var prestitiBibliotecaContext = _context.Prestiti.Include(p => p.IdLibroNavigation).Include(p => p.MatricolaNavigation).OrderByDescending(x=>x.DataPrestito);
            return View(await prestitiBibliotecaContext.ToListAsync());
        }

        // GET: Prestiti/Details/5
        public async Task<IActionResult> Details(int? idlibro, int? matricola)
        {
            if (idlibro == null || matricola == null)
            {
                return NotFound();
            }

            var prestito = await _context.Prestiti
                .Include(p => p.IdLibroNavigation)
                .Include(p => p.MatricolaNavigation)
                .FirstOrDefaultAsync(m => m.IdLibro == idlibro && m.Matricola==matricola);
            if (prestito == null)
            {
                return NotFound();
            }

            return View(prestito);
        }

        // GET: Prestiti/Create
        public IActionResult Create()
        {
            ViewData["IdLibro"] = new SelectList(_context.Libri, "Codice", "Codice");
            ViewData["Matricola"] = new SelectList(_context.Studenti, "Matricola", "Matricola");
            return View();
        }

        // POST: Prestiti/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLibro,Matricola,DataPrestito,DataRestituzione")] Prestito prestito)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prestito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLibro"] = new SelectList(_context.Libri, "Codice", "Codice", prestito.IdLibro);
            ViewData["Matricola"] = new SelectList(_context.Studenti, "Matricola", "Matricola", prestito.Matricola);
            return View(prestito);
        }

        // GET: Prestiti/Edit/5
        public async Task<IActionResult> Edit(int? idlibro, int? matricola)
        {
            if (idlibro == null || matricola==null)
            {
                return NotFound();
            }

            var prestito = await _context.Prestiti
                .Include(p => p.IdLibroNavigation)
                .Include(p => p.MatricolaNavigation)
                .FirstOrDefaultAsync(m => m.IdLibro == idlibro && m.Matricola == matricola);
            if (prestito == null)
            {
                return NotFound();
            }
            ViewData["IdLibro"] = new SelectList(_context.Libri, "Codice", "Codice", prestito.IdLibro);
            ViewData["Matricola"] = new SelectList(_context.Studenti, "Matricola", "Matricola", prestito.Matricola);
            return View(prestito);
        }

        // POST: Prestiti/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int idlibro, int matricola, [Bind("IdLibro,Matricola,DataPrestito,DataRestituzione")] Prestito prestito)
        {
            if (idlibro != prestito.IdLibro || matricola!=prestito.Matricola)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
                try
                {
                    _context.Update(prestito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrestitoExists(prestito.IdLibro, prestito.Matricola))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            //}
            //ViewData["IdLibro"] = new SelectList(_context.Libri, "Codice", "Codice", prestito.IdLibro);
            //ViewData["Matricola"] = new SelectList(_context.Studenti, "Matricola", "Matricola", prestito.Matricola);
            //return View(prestito);
        }

        // GET: Prestiti/Delete/5
        public async Task<IActionResult> Delete(int? idlibro, int? matricola)
        {
            if (idlibro == null || matricola == null)
            {
                return NotFound();
            }

            var prestito = await _context.Prestiti
                .Include(p => p.IdLibroNavigation)
                .Include(p => p.MatricolaNavigation)
                .FirstOrDefaultAsync(m => m.IdLibro == idlibro && m.Matricola==matricola);
            if (prestito == null)
            {
                return NotFound();
            }

            return View(prestito);
        }

        // POST: Prestiti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int idlibro, int matricola)
        {
            var prestito = await _context.Prestiti.FindAsync(idlibro, matricola);
            if (prestito != null)
            {
                _context.Prestiti.Remove(prestito);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrestitoExists(int idlibro, int matricola)
        {
            return _context.Prestiti.Any(e => e.IdLibro == idlibro && e.Matricola==matricola);
        }

        public async Task<IActionResult> LibriNonRestituiti()
        {
            var prestitiBibliotecaContext = _context.Prestiti.Include(p => p.IdLibroNavigation).Include(p => p.MatricolaNavigation).Where(p=>p.DataRestituzione==null).OrderByDescending(x => x.DataPrestito);
            return View(await prestitiBibliotecaContext.ToListAsync());
        }

        public async Task<IActionResult> PrestitiScaduti()
        {
            var scad = new TimeSpan(60, 0, 0);
            var prestitiBibliotecaContext = _context.Prestiti.Include(p => p.IdLibroNavigation).Include(p => p.MatricolaNavigation).Where(p => p.DataRestituzione == null).Where(p=>DateTime.Today>p.DataPrestito.AddDays(60)).OrderByDescending(x => x.DataPrestito);
            return View(await prestitiBibliotecaContext.ToListAsync());
        }
    }
}

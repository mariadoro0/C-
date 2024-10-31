using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrestitiVideoteca.Models;

namespace PrestitiVideoteca.Controllers
{
    public class PrestitiController : Controller
    {
        private readonly PrestitiVideotecaContext _context;

        public PrestitiController(PrestitiVideotecaContext context)
        {
            _context = context;
        }

        // GET: Prestiti
        public async Task<IActionResult> Index(string titolo, string cognome)
        {
            var prestitiVideotecaContext = _context.Prestiti.Include(p => p.IdFilmNavigation).Include(p => p.MatricolaNavigation).Where(p=>p.DataRestituzione == null).OrderByDescending(p=>p.DataPrestito).IgnoreQueryFilters();
            if (!string.IsNullOrEmpty(cognome))
                prestitiVideotecaContext = prestitiVideotecaContext.Where(x => x.MatricolaNavigation.Cognome.Contains(cognome));
            if (!string.IsNullOrEmpty(titolo))
                prestitiVideotecaContext = prestitiVideotecaContext.Where(x => x.IdFilmNavigation.Titolo.Contains(titolo));
            ViewBag.Titolo = titolo;
            ViewBag.Cognome = cognome;
            ViewBag.Header = "Prestiti attivi";
            ViewBag.IndexCheck = 1;
            return View(await prestitiVideotecaContext.ToListAsync());
        }
        public async Task<IActionResult> IndexArchivio(string titolo, string cognome)
        {
            var prestitiVideotecaContext = _context.Prestiti.Include(p => p.IdFilmNavigation).Include(p => p.MatricolaNavigation).Where(p => p.DataRestituzione != null).OrderByDescending(p => p.DataPrestito).IgnoreQueryFilters();
            if (!string.IsNullOrEmpty(cognome))
                prestitiVideotecaContext = prestitiVideotecaContext.Where(x => x.MatricolaNavigation.Cognome.Contains(cognome));
            if (!string.IsNullOrEmpty(titolo))
                prestitiVideotecaContext = prestitiVideotecaContext.Where(x => x.IdFilmNavigation.Titolo.Contains(titolo));
            ViewBag.Titolo = titolo;
            ViewBag.Cognome = cognome;
            ViewBag.Header = "Archivio prestiti";
            ViewBag.IndexCheck = 2;
            return View("Index",await prestitiVideotecaContext.ToListAsync());
        }

        // GET: Prestiti/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestito = await _context.Prestiti
                .Include(p => p.IdFilmNavigation)
                .Include(p => p.MatricolaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prestito == null)
            {
                return NotFound();
            }

            return View(prestito);
        }

        // GET: Prestiti/Create
        public IActionResult Create()
        {
            
            ViewData["IdFilm"] = new SelectList(_context.Films, "Codice", "Titolo");
            ViewData["Matricola"] = new SelectList(_context.Studenti, "Matricola", "Nominativo");
            
            return View();
        }
        public IActionResult ClassificaPrestitiFilm()
        {
            var prestiti = _context.Films.Include(x=>x.Prestiti).ToList();
            var classifica = new List<ClassificaFilmViewModel>();
            foreach(var f in prestiti)
            {
                classifica.Add(new ClassificaFilmViewModel { Film = f, NPrestiti = _context.Prestiti.Where(x=>x.IdFilm==f.Codice).Count() });
            }
            return View(classifica.OrderByDescending(x => x.NPrestiti).Take(10));
        }

        // POST: Prestiti/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdFilm,Matricola,DataPrestito,DataRestituzione")] Prestito prestito)
        {
            if (ModelState.IsValid)
            {
                prestito.DataPrestito = DateTime.Now;
                
                _context.Add(prestito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdFilm"] = new SelectList(_context.Films, "Codice", "Codice", prestito.IdFilm);
            ViewData["Matricola"] = new SelectList(_context.Studenti, "Matricola", "Matricola", prestito.Matricola);
            return View(prestito);
        }

        // GET: Prestiti/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestito = await _context.Prestiti.FindAsync(id);
            if (prestito == null)
            {
                return NotFound();
            }
            ViewData["IdFilm"] = new SelectList(_context.Films, "Codice", "Codice", prestito.IdFilm);
            ViewData["Matricola"] = new SelectList(_context.Studenti, "Matricola", "Matricola", prestito.Matricola);
            return View(prestito);
        }

        // POST: Prestiti/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdFilm,Matricola,DataPrestito,DataRestituzione")] Prestito prestito)
        {
            if (id != prestito.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prestito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrestitoExists(prestito.Id))
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
            ViewData["IdFilm"] = new SelectList(_context.Films, "Codice", "Codice", prestito.IdFilm);
            ViewData["Matricola"] = new SelectList(_context.Studenti, "Matricola", "Matricola", prestito.Matricola);
            return View(prestito);
        }

        // GET: Prestiti/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestito = await _context.Prestiti
                .Include(p => p.IdFilmNavigation)
                .Include(p => p.MatricolaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prestito == null)
            {
                return NotFound();
            }

            return View(prestito);
        }

        // POST: Prestiti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prestito = await _context.Prestiti.FindAsync(id);
            if (prestito != null)
            {
                _context.Prestiti.Remove(prestito);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrestitoExists(int id)
        {
            return _context.Prestiti.Any(e => e.Id == id);
        }

      

        public async Task<IActionResult> Restituzione(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestito = await _context.Prestiti
                .Include(p => p.IdFilmNavigation)
                .Include(p => p.MatricolaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prestito == null)
            {
                return NotFound();
            }

            return View(prestito);
        }

        // POST: Prestiti/Delete/5
        [HttpPost, ActionName("Restituzione")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RestituisciConfirmed(int id)
        {
            var prestito = await _context.Prestiti.FindAsync(id);
            if (prestito != null)
            {
                prestito.DataRestituzione = DateTime.Now;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
    }
}

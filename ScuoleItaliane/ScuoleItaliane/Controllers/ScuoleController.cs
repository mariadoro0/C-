using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScuoleItaliane.Models;

namespace ScuoleItaliane.Controllers
{
    public class ScuoleController : Controller
    {
        private readonly ScuoleItalianeContext _context;

        public ScuoleController(ScuoleItalianeContext context)
        {
            _context = context;
        }

        // GET: Scuole
        public async Task<IActionResult> Index(string? regione, bool litoranea, string? comune, string? scuola)
        {
            var lista = _context.Scuole
                .Include(s => s.IdCaratteristicaScuolaNavigation)
                .Include(s => s.IdComuneNavigation.IdProvinciaNavigation.IdRegioneNavigation)
                .Include(s => s.IdIstitutoRiferimentoNavigation)
                .Include(s => s.IdTipologiaScuolaNavigation).AsQueryable();

            if (!string.IsNullOrEmpty(regione))
            {
                lista = lista.Where(x=>x.IdComuneNavigation.IdProvinciaNavigation.IdRegioneNavigation.Denominazione.Equals(regione));
            }
            if (litoranea)
            {
                lista = lista.Where(x => x.IdComuneNavigation.ComuneLitoraneo == true);
                Console.WriteLine(lista);
                Console.WriteLine(litoranea);

            }
            if (!string.IsNullOrEmpty(comune))
            {
                lista = lista.Where(x => x.IdComuneNavigation.Denominazione.Equals(comune));
            }
            if (!string.IsNullOrEmpty(scuola))
            {
                lista = lista.Where(x => x.Denominazione.Contains(scuola));
            }
            ViewBag.NomeScuola = scuola;
            ViewBag.Comune = comune;
            ViewBag.Regione = regione;
            ViewBag.Regioni = _context.Regioni.Select(x => x.Denominazione).Distinct().ToList();
            return View(await lista.Take(200).ToListAsync());
        }
    }
}

        // GET: Scuole/Details/5
        /*
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scuola = await _context.Scuole
                .Include(s => s.IdCaratteristicaScuolaNavigation)
                .Include(s => s.IdComuneNavigation)
                .Include(s => s.IdIstitutoRiferimentoNavigation)
                .Include(s => s.IdTipologiaScuolaNavigation)
                .FirstOrDefaultAsync(m => m.CodiceScuola == id);
            if (scuola == null)
            {
                return NotFound();
            }

            return View(scuola);
        }

        // GET: Scuole/Create
        public IActionResult Create()
        {
            ViewData["IdCaratteristicaScuola"] = new SelectList(_context.CaratteristicaScuole, "Id", "Id");
            ViewData["IdComune"] = new SelectList(_context.Comuni, "CodiceCatastale", "CodiceCatastale");
            ViewData["IdIstitutoRiferimento"] = new SelectList(_context.IstitutiRiferimento, "CodiceIstituto", "CodiceIstituto");
            ViewData["IdTipologiaScuola"] = new SelectList(_context.TipologieScuole, "Id", "Id");
            return View();
        }

        // POST: Scuole/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodiceScuola,Denominazione,SedeDirettiva,Indirizzo,Cap,Email,Pec,SitoWeb,IstitutoOmniComprensivo,IdIstitutoRiferimento,IdComune,IdCaratteristicaScuola,IdTipologiaScuola")] Scuola scuola)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scuola);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCaratteristicaScuola"] = new SelectList(_context.CaratteristicaScuole, "Id", "Id", scuola.IdCaratteristicaScuola);
            ViewData["IdComune"] = new SelectList(_context.Comuni, "CodiceCatastale", "CodiceCatastale", scuola.IdComune);
            ViewData["IdIstitutoRiferimento"] = new SelectList(_context.IstitutiRiferimento, "CodiceIstituto", "CodiceIstituto", scuola.IdIstitutoRiferimento);
            ViewData["IdTipologiaScuola"] = new SelectList(_context.TipologieScuole, "Id", "Id", scuola.IdTipologiaScuola);
            return View(scuola);
        }

        // GET: Scuole/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scuola = await _context.Scuole.FindAsync(id);
            if (scuola == null)
            {
                return NotFound();
            }
            ViewData["IdCaratteristicaScuola"] = new SelectList(_context.CaratteristicaScuole, "Id", "Id", scuola.IdCaratteristicaScuola);
            ViewData["IdComune"] = new SelectList(_context.Comuni, "CodiceCatastale", "CodiceCatastale", scuola.IdComune);
            ViewData["IdIstitutoRiferimento"] = new SelectList(_context.IstitutiRiferimento, "CodiceIstituto", "CodiceIstituto", scuola.IdIstitutoRiferimento);
            ViewData["IdTipologiaScuola"] = new SelectList(_context.TipologieScuole, "Id", "Id", scuola.IdTipologiaScuola);
            return View(scuola);
        }

        // POST: Scuole/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CodiceScuola,Denominazione,SedeDirettiva,Indirizzo,Cap,Email,Pec,SitoWeb,IstitutoOmniComprensivo,IdIstitutoRiferimento,IdComune,IdCaratteristicaScuola,IdTipologiaScuola")] Scuola scuola)
        {
            if (id != scuola.CodiceScuola)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scuola);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScuolaExists(scuola.CodiceScuola))
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
            ViewData["IdCaratteristicaScuola"] = new SelectList(_context.CaratteristicaScuole, "Id", "Id", scuola.IdCaratteristicaScuola);
            ViewData["IdComune"] = new SelectList(_context.Comuni, "CodiceCatastale", "CodiceCatastale", scuola.IdComune);
            ViewData["IdIstitutoRiferimento"] = new SelectList(_context.IstitutiRiferimento, "CodiceIstituto", "CodiceIstituto", scuola.IdIstitutoRiferimento);
            ViewData["IdTipologiaScuola"] = new SelectList(_context.TipologieScuole, "Id", "Id", scuola.IdTipologiaScuola);
            return View(scuola);
        }

        // GET: Scuole/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scuola = await _context.Scuole
                .Include(s => s.IdCaratteristicaScuolaNavigation)
                .Include(s => s.IdComuneNavigation)
                .Include(s => s.IdIstitutoRiferimentoNavigation)
                .Include(s => s.IdTipologiaScuolaNavigation)
                .FirstOrDefaultAsync(m => m.CodiceScuola == id);
            if (scuola == null)
            {
                return NotFound();
            }

            return View(scuola);
        }

        // POST: Scuole/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var scuola = await _context.Scuole.FindAsync(id);
            if (scuola != null)
            {
                _context.Scuole.Remove(scuola);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScuolaExists(string id)
        {
            return _context.Scuole.Any(e => e.CodiceScuola == id);
        }
    }
}*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrestitiVideoteca.Models;
using PrestitiVideoteca.Controllers;
using Microsoft.AspNetCore.Authorization;


namespace PrestitiVideoteca.Controllers
{
    public class StudentiController : Controller
    {
        private readonly PrestitiVideotecaContext _context;

        public StudentiController(PrestitiVideotecaContext context)
        {
            _context = context;
        }

        // GET: Studenti
        public async Task<IActionResult> Index(string nome, string cognome)
        {
            ViewBag.Nome = nome;
            ViewBag.Cognome = cognome;
             var lista = _context.Studenti.IgnoreQueryFilters();
            if (!string.IsNullOrEmpty(nome))
            {
                lista = lista.Where(x => x.Nome.Contains(nome));
            }
            if(!string.IsNullOrEmpty(cognome))
            {
                lista = lista.Where(x=>x.Cognome.Contains(cognome));
            }
            return View(await lista.ToListAsync());
        }

        // GET: Studenti/Details/5

        //[Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studente = await _context.Studenti
                .FirstOrDefaultAsync(m => m.Matricola == id);
            ViewBag.Prestiti = _context.Prestiti.Include(f =>f.IdFilmNavigation).Where(m => m.Matricola == id).ToList();
            if (studente == null)
            {
                return NotFound();
            }


            return View(studente);
        }

        public IActionResult ClassificaPrestitiStudenti()
        {
            var prestiti = _context.Studenti.Include(x => x.Prestiti).ToList();
            var classifica = new List<ClassificaStudentiViewModel>();
            foreach (var f in prestiti)
            {
                classifica.Add(new ClassificaStudentiViewModel { Studente = f, NPrestiti = _context.Prestiti.Where(x => x.Matricola == f.Matricola).Count() });
            }
            return View(classifica.OrderByDescending(x => x.NPrestiti).Take(10));
        }

        // GET: Studenti/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Studenti/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Matricola,Nome,Cognome,Email,Classe")] Studente studente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studente);
        }

        // GET: Studenti/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studente = await _context.Studenti.FindAsync(id);
            if (studente == null)
            {
                return NotFound();
            }
            return View(studente);
        }

        // POST: Studenti/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Matricola,Nome,Cognome,Email,Classe")] Studente studente)
        {
            if (id != studente.Matricola)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudenteExists(studente.Matricola))
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
            return View(studente);
        }

        // GET: Studenti/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studente = await _context.Studenti
                .FirstOrDefaultAsync(m => m.Matricola == id);
            if (studente == null)
            {
                return NotFound();
            }

            return View(studente);
        }

        // POST: Studenti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studente = await _context.Studenti.FindAsync(id);
            if (studente != null)
            {
                _context.Studenti.Remove(studente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudenteExists(int id)
        {
            return _context.Studenti.Any(e => e.Matricola == id);
        }
    }
}

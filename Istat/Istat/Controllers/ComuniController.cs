﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Istat.Models;

namespace Istat.Controllers
{
    public class ComuniController : Controller
    {
        private readonly Istat2015Context _context;

        public ComuniController(Istat2015Context context)
        {
            _context = context;
        }

        // GET: Comuni
        public async Task<IActionResult> Index(string? comune, int? popolazione)
        {
            var istat2015Context = _context.Comuni.Include(c => c.IdProvinciaNavigation).Include(c => c.IdZonaAltimetricaNavigation).Include(c => c.IdZonaMontanaNavigation).AsQueryable();
            if (!string.IsNullOrEmpty(comune))
            {
                istat2015Context = istat2015Context.Where(x=>x.Denominazione.Contains(comune));
            }
            if(popolazione != null)
            {
                istat2015Context = istat2015Context.Where(x => x.Popolazione2011 >= popolazione);
            }
            ViewBag.Comune = comune;
            return View(await istat2015Context.ToListAsync());
        }

        // GET: Comuni/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comune = await _context.Comuni
                .Include(c => c.IdProvinciaNavigation)
                .Include(c => c.IdZonaAltimetricaNavigation)
                .Include(c => c.IdZonaMontanaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comune == null)
            {
                return NotFound();
            }

            return View(comune);
        }

        // GET: Comuni/Create
        public IActionResult Create()
        {
            ViewData["IdProvincia"] = new SelectList(_context.Province, "Id", "Id");
            ViewData["IdZonaAltimetrica"] = new SelectList(_context.ZonaAltimetrica, "Id", "Id");
            ViewData["IdZonaMontana"] = new SelectList(_context.ZonaMontana, "Id", "Id");
            return View();
        }

        // POST: Comuni/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdProvincia,Denominazione,CodiceCatastale,ComuneCapoluogo,AltitudineCentro,ZonaLitoranea,IdZonaAltimetrica,IdZonaMontana,Superficie,Popolazione2001,Popolazione2011")] Comune comune)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comune);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProvincia"] = new SelectList(_context.Province, "Id", "Id", comune.IdProvincia);
            ViewData["IdZonaAltimetrica"] = new SelectList(_context.ZonaAltimetrica, "Id", "Id", comune.IdZonaAltimetrica);
            ViewData["IdZonaMontana"] = new SelectList(_context.ZonaMontana, "Id", "Id", comune.IdZonaMontana);
            return View(comune);
        }

        // GET: Comuni/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comune = await _context.Comuni.FindAsync(id);
            if (comune == null)
            {
                return NotFound();
            }
            ViewData["IdProvincia"] = new SelectList(_context.Province, "Id", "Id", comune.IdProvincia);
            ViewData["IdZonaAltimetrica"] = new SelectList(_context.ZonaAltimetrica, "Id", "Id", comune.IdZonaAltimetrica);
            ViewData["IdZonaMontana"] = new SelectList(_context.ZonaMontana, "Id", "Id", comune.IdZonaMontana);
            return View(comune);
        }

        // POST: Comuni/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdProvincia,Denominazione,CodiceCatastale,ComuneCapoluogo,AltitudineCentro,ZonaLitoranea,IdZonaAltimetrica,IdZonaMontana,Superficie,Popolazione2001,Popolazione2011")] Comune comune)
        {
            if (id != comune.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comune);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComuneExists(comune.Id))
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
            ViewData["IdProvincia"] = new SelectList(_context.Province, "Id", "Id", comune.IdProvincia);
            ViewData["IdZonaAltimetrica"] = new SelectList(_context.ZonaAltimetrica, "Id", "Id", comune.IdZonaAltimetrica);
            ViewData["IdZonaMontana"] = new SelectList(_context.ZonaMontana, "Id", "Id", comune.IdZonaMontana);
            return View(comune);
        }

        // GET: Comuni/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comune = await _context.Comuni
                .Include(c => c.IdProvinciaNavigation)
                .Include(c => c.IdZonaAltimetricaNavigation)
                .Include(c => c.IdZonaMontanaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comune == null)
            {
                return NotFound();
            }

            return View(comune);
        }

        // POST: Comuni/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comune = await _context.Comuni.FindAsync(id);
            if (comune != null)
            {
                _context.Comuni.Remove(comune);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComuneExists(int id)
        {
            return _context.Comuni.Any(e => e.Id == id);
        }
    }
}

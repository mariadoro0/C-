using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnagraficaAPI.Models;

namespace AnagraficaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentiController : ControllerBase
    {
        private readonly AnagraficaContext _context;

        public StudentiController(AnagraficaContext context)
        {
            _context = context;
        }

        // GET: api/Studenti
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Studente>>> GetStudenti()
        {
            return await _context.Studenti.ToListAsync();
        }

        // GET: api/Studenti/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Studente>> GetStudente(short id)
        {
            var studente = await _context.Studenti.FindAsync(id);

            if (studente == null)
            {
                return NotFound();
            }

            return studente;
        }

        // PUT: api/Studenti/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudente(short id, Studente studente)
        {
            if (id != studente.Matricola)
            {
                return BadRequest();
            }

            _context.Entry(studente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudenteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Studenti
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Studente>> PostStudente(Studente studente)
        {
            _context.Studenti.Add(studente);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudenteExists(studente.Matricola))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStudente", new { id = studente.Matricola }, studente);
        }

        // DELETE: api/Studenti/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudente(short id)
        {
            var studente = await _context.Studenti.FindAsync(id);
            if (studente == null)
            {
                return NotFound();
            }

            _context.Studenti.Remove(studente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudenteExists(short id)
        {
            return _context.Studenti.Any(e => e.Matricola == id);
        }
    }
}

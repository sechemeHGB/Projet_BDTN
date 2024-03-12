using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projet_BDTN.Data;
using Projet_BDTN.Models;

namespace Projet_BDTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentesController : ControllerBase
    {
        private readonly Projet_BDTNContext _context;

        public VentesController(Projet_BDTNContext context)
        {
            _context = context;
        }

        // GET: api/Ventes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vente>>> GetVente()
        {
          if (_context.Vente == null)
          {
              return NotFound();
          }
            return await _context.Vente.ToListAsync();
        }

        // GET: api/Ventes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vente>> GetVente(int id)
        {
          if (_context.Vente == null)
          {
              return NotFound();
          }
            var vente = await _context.Vente.FindAsync(id);

            if (vente == null)
            {
                return NotFound();
            }

            return vente;
        }

        // PUT: api/Ventes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVente(int id, Vente vente)
        {
            if (id != vente.id)
            {
                return BadRequest();
            }

            _context.Entry(vente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VenteExists(id))
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

        // POST: api/Ventes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vente>> PostVente(Vente vente)
        {
          if (_context.Vente == null)
          {
              return Problem("Entity set 'Projet_BDTNContext.Vente'  is null.");
          }
            _context.Vente.Add(vente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVente", new { id = vente.id }, vente);
        }

        // DELETE: api/Ventes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVente(int id)
        {
            if (_context.Vente == null)
            {
                return NotFound();
            }
            var vente = await _context.Vente.FindAsync(id);
            if (vente == null)
            {
                return NotFound();
            }

            _context.Vente.Remove(vente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VenteExists(int id)
        {
            return (_context.Vente?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}

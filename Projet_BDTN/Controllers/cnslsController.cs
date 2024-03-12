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
    public class cnslsController : ControllerBase
    {
        private readonly Projet_BDTNContext _context;

        public cnslsController(Projet_BDTNContext context)
        {
            _context = context;
        }

        // GET: api/cnsls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cnsl>>> GetConsole()
        {
          if (_context.Console == null)
          {
              return NotFound();
          }
            return await _context.Console.ToListAsync();
        }

        // GET: api/cnsls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<cnsl>> Getcnsl(int id)
        {
          if (_context.Console == null)
          {
              return NotFound();
          }
            var cnsl = await _context.Console.FindAsync(id);

            if (cnsl == null)
            {
                return NotFound();
            }

            return cnsl;
        }

        // PUT: api/cnsls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcnsl(int id, cnsl cnsl)
        {
            if (id != cnsl.Id)
            {
                return BadRequest();
            }

            _context.Entry(cnsl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cnslExists(id))
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

        // POST: api/cnsls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<cnsl>> Postcnsl(cnsl cnsl)
        {
          if (_context.Console == null)
          {
              return Problem("Entity set 'Projet_BDTNContext.Console'  is null.");
          }
            _context.Console.Add(cnsl);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcnsl", new { id = cnsl.Id }, cnsl);
        }

        // DELETE: api/cnsls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecnsl(int id)
        {
            if (_context.Console == null)
            {
                return NotFound();
            }
            var cnsl = await _context.Console.FindAsync(id);
            if (cnsl == null)
            {
                return NotFound();
            }

            _context.Console.Remove(cnsl);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool cnslExists(int id)
        {
            return (_context.Console?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

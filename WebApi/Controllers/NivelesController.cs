using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models.Context;
using WebApi.Models.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NivelesController : ControllerBase
    {
        private readonly SecContext _context;

        public NivelesController(SecContext context)
        {
            _context = context;
        }

        // GET: api/Niveles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Niveles>>> GetNiveles()
        {
            return await _context.Niveles.ToListAsync();
        }

        // GET: api/Niveles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Niveles>> GetNiveles(int id)
        {
            var niveles = await _context.Niveles.FindAsync(id);

            if (niveles == null)
            {
                return NotFound();
            }

            return niveles;
        }

        // PUT: api/Niveles/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNiveles(int id, Niveles niveles)
        {
            if (id != niveles.IdNivel)
            {
                return BadRequest();
            }

            _context.Entry(niveles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NivelesExists(id))
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

        // POST: api/Niveles
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Niveles>> PostNiveles(Niveles niveles)
        {
            _context.Niveles.Add(niveles);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNiveles", new { id = niveles.IdNivel }, niveles);
        }

        // DELETE: api/Niveles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Niveles>> DeleteNiveles(int id)
        {
            var niveles = await _context.Niveles.FindAsync(id);
            if (niveles == null)
            {
                return NotFound();
            }

            _context.Niveles.Remove(niveles);
            await _context.SaveChangesAsync();

            return niveles;
        }

        private bool NivelesExists(int id)
        {
            return _context.Niveles.Any(e => e.IdNivel == id);
        }
    }
}

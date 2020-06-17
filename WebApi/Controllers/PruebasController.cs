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
    public class PruebasController : ControllerBase
    {
        private readonly SecContext _context;

        public PruebasController(SecContext context)
        {
            _context = context;
        }

        // GET: api/Pruebas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pruebas>>> GetPruebas()
        {
            return await _context.Pruebas.ToListAsync();
        }

        // GET: api/Pruebas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pruebas>> GetPruebas(int id)
        {
            var pruebas = await _context.Pruebas.FindAsync(id);

            if (pruebas == null)
            {
                return NotFound();
            }

            return pruebas;
        }

        // PUT: api/Pruebas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPruebas(int id, Pruebas pruebas)
        {
            if (id != pruebas.IdPrueba)
            {
                return BadRequest();
            }

            _context.Entry(pruebas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PruebasExists(id))
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

        // POST: api/Pruebas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Pruebas>> PostPruebas(Pruebas pruebas)
        {
            _context.Pruebas.Add(pruebas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPruebas", new { id = pruebas.IdPrueba }, pruebas);
        }

        // DELETE: api/Pruebas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pruebas>> DeletePruebas(int id)
        {
            var pruebas = await _context.Pruebas.FindAsync(id);
            if (pruebas == null)
            {
                return NotFound();
            }

            _context.Pruebas.Remove(pruebas);
            await _context.SaveChangesAsync();

            return pruebas;
        }

        private bool PruebasExists(int id)
        {
            return _context.Pruebas.Any(e => e.IdPrueba == id);
        }
    }
}

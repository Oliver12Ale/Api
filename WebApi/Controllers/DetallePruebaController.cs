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
    public class DetallePruebaController : ControllerBase
    {
        private readonly SecContext _context;

        public DetallePruebaController(SecContext context)
        {
            _context = context;
        }

        // GET: api/DetallePrueba
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallePrueba>>> GetDetallePrueba()
        {
            return await _context.DetallePrueba.ToListAsync();
        }

        // GET: api/DetallePrueba/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetallePrueba>> GetDetallePrueba(int id)
        {
            var detallePrueba = await _context.DetallePrueba.FindAsync(id);

            if (detallePrueba == null)
            {
                return NotFound();
            }

            return detallePrueba;
        }

        // PUT: api/DetallePrueba/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetallePrueba(int id, DetallePrueba detallePrueba)
        {
            if (id != detallePrueba.IdDetallePrueba)
            {
                return BadRequest();
            }

            _context.Entry(detallePrueba).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetallePruebaExists(id))
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

        // POST: api/DetallePrueba
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DetallePrueba>> PostDetallePrueba(DetallePrueba detallePrueba)
        {
            _context.DetallePrueba.Add(detallePrueba);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetallePrueba", new { id = detallePrueba.IdDetallePrueba }, detallePrueba);
        }

        // DELETE: api/DetallePrueba/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DetallePrueba>> DeleteDetallePrueba(int id)
        {
            var detallePrueba = await _context.DetallePrueba.FindAsync(id);
            if (detallePrueba == null)
            {
                return NotFound();
            }

            _context.DetallePrueba.Remove(detallePrueba);
            await _context.SaveChangesAsync();

            return detallePrueba;
        }

        private bool DetallePruebaExists(int id)
        {
            return _context.DetallePrueba.Any(e => e.IdDetallePrueba == id);
        }
    }
}

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
    public class TecnologiasController : ControllerBase
    {
        private readonly SecContext _context;

        public TecnologiasController(SecContext context)
        {
            _context = context;
        }

        // GET: api/Tecnologias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tecnologias>>> GetTecnologias()
        {
            return await _context.Tecnologias.ToListAsync();
        }

        // GET: api/Tecnologias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tecnologias>> GetTecnologias(int id)
        {
            var tecnologias = await _context.Tecnologias.FindAsync(id);

            if (tecnologias == null)
            {
                return NotFound();
            }

            return tecnologias;
        }

        // PUT: api/Tecnologias/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTecnologias(int id, Tecnologias tecnologias)
        {
            if (id != tecnologias.IdTecnologia)
            {
                return BadRequest();
            }

            _context.Entry(tecnologias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TecnologiasExists(id))
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

        // POST: api/Tecnologias
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Tecnologias>> PostTecnologias(Tecnologias tecnologias)
        {
            _context.Tecnologias.Add(tecnologias);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTecnologias", new { id = tecnologias.IdTecnologia }, tecnologias);
        }

        // DELETE: api/Tecnologias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tecnologias>> DeleteTecnologias(int id)
        {
            var tecnologias = await _context.Tecnologias.FindAsync(id);
            if (tecnologias == null)
            {
                return NotFound();
            }

            _context.Tecnologias.Remove(tecnologias);
            await _context.SaveChangesAsync();

            return tecnologias;
        }

        private bool TecnologiasExists(int id)
        {
            return _context.Tecnologias.Any(e => e.IdTecnologia == id);
        }
    }
}

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
    public class PreguntasController : ControllerBase
    {
        private readonly SecContext _context;

        public PreguntasController(SecContext context)
        {
            _context = context;
        }

        // GET: api/Preguntas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Preguntas>>> GetPreguntas()
        {
            return await _context.Preguntas.Include(ops =>ops.Opciones).ToListAsync();
        }

        // GET: api/Preguntas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Preguntas>> GetPreguntas(int id)
        {
            var preguntas = await _context.Preguntas.FindAsync(id);

            if (preguntas == null)
            {
                return NotFound();
            }

            return preguntas;
        }


        // GET: api/Preguntas
        [HttpGet]
        [Route("[action]/{idtecnologia}/{noPreguntas}")]
        public async Task<ActionResult<IEnumerable<Preguntas>>> Random(int idtecnologia, int noPreguntas) { 
            return await _context.Preguntas.FromSqlRaw("PreguntasporTecnologia {0},{1}", idtecnologia,noPreguntas).ToArrayAsync();
        }

        // GET: api/Preguntas
        [HttpGet]
        [Route("[action]/{idtecnologia}")]
        public async Task<ActionResult<IEnumerable<Preguntas>>> porTecnologia(int idtecnologia)
        {
            return await _context.Preguntas.Where(p=>p.IdTecnologia==idtecnologia)
                .Include(ops => ops.Opciones).ToArrayAsync();
        }

        // PUT: api/Preguntas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreguntas(int id, Preguntas preguntas)
        {
            if (id != preguntas.IdPregunta)
            {
                return BadRequest();
            }

            _context.Entry(preguntas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreguntasExists(id))
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

        // POST: api/Preguntas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Preguntas>> PostPreguntas(Preguntas preguntas)
        {
            _context.Preguntas.Add(preguntas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreguntas", new { id = preguntas.IdPregunta }, preguntas);
        }

        // DELETE: api/Preguntas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Preguntas>> DeletePreguntas(int id)
        {
            var preguntas = await _context.Preguntas.FindAsync(id);
            if (preguntas == null)
            {
                return NotFound();
            }

            _context.Preguntas.Remove(preguntas);
            await _context.SaveChangesAsync();

            return preguntas;
        }

        private bool PreguntasExists(int id)
        {
            return _context.Preguntas.Any(e => e.IdPregunta == id);
        }
    }
}

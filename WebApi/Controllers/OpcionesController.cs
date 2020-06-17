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
    public class OpcionesController : ControllerBase
    {
        private readonly SecContext _context;

        public OpcionesController(SecContext context)
        {
            _context = context;
        }

        // GET: api/Opciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Opciones>>> GetOpciones()
        {
            return await _context.Opciones.ToListAsync();
        }

        // GET: api/Opciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Opciones>> GetOpciones(int id)
        {
            var opciones = await _context.Opciones.FindAsync(id);

            if (opciones == null)
            {
                return NotFound();
            }

            return opciones;
        }

        // PUT: api/Opciones/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOpciones(int id, Opciones opciones)
        {
            if (id != opciones.IdOpcion)
            {
                return BadRequest();
            }

            _context.Entry(opciones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OpcionesExists(id))
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

        // POST: api/Opciones
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Opciones>> PostOpciones(Opciones opciones)
        {
            _context.Opciones.Add(opciones);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOpciones", new { id = opciones.IdOpcion }, opciones);
        }

        // DELETE: api/Opciones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Opciones>> DeleteOpciones(int id)
        {
            var opciones = await _context.Opciones.FindAsync(id);
            if (opciones == null)
            {
                return NotFound();
            }

            _context.Opciones.Remove(opciones);
            await _context.SaveChangesAsync();

            return opciones;
        }

        private bool OpcionesExists(int id)
        {
            return _context.Opciones.Any(e => e.IdOpcion == id);
        }
    }
}

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
    public class NivelesUsuariosController : ControllerBase
    {
        private readonly SecContext _context;

        public NivelesUsuariosController(SecContext context)
        {
            _context = context;
        }

        // GET: api/NivelesUsuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NivelesUsuarios>>> GetNivelesUsuarios()
        {
            return await _context.NivelesUsuarios.ToListAsync();
        }

        // GET: api/NivelesUsuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NivelesUsuarios>> GetNivelesUsuarios(int id)
        {
            var nivelesUsuarios = await _context.NivelesUsuarios.FindAsync(id);

            if (nivelesUsuarios == null)
            {
                return NotFound();
            }

            return nivelesUsuarios;
        }

        // PUT: api/NivelesUsuarios/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNivelesUsuarios(int id, NivelesUsuarios nivelesUsuarios)
        {
            if (id != nivelesUsuarios.IdNivelUsuario)
            {
                return BadRequest();
            }

            _context.Entry(nivelesUsuarios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NivelesUsuariosExists(id))
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

        // POST: api/NivelesUsuarios
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<NivelesUsuarios>> PostNivelesUsuarios(NivelesUsuarios nivelesUsuarios)
        {
            _context.NivelesUsuarios.Add(nivelesUsuarios);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNivelesUsuarios", new { id = nivelesUsuarios.IdNivelUsuario }, nivelesUsuarios);
        }

        // DELETE: api/NivelesUsuarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NivelesUsuarios>> DeleteNivelesUsuarios(int id)
        {
            var nivelesUsuarios = await _context.NivelesUsuarios.FindAsync(id);
            if (nivelesUsuarios == null)
            {
                return NotFound();
            }

            _context.NivelesUsuarios.Remove(nivelesUsuarios);
            await _context.SaveChangesAsync();

            return nivelesUsuarios;
        }

        private bool NivelesUsuariosExists(int id)
        {
            return _context.NivelesUsuarios.Any(e => e.IdNivelUsuario == id);
        }
    }
}

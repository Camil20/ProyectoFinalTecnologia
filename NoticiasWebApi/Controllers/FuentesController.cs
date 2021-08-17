using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoticiasWebApi.Data;
using NoticiasWebApi.Models;

namespace NoticiasWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuentesController : ControllerBase
    {
        private readonly ApiNoticiasContext _context;

        public FuentesController(ApiNoticiasContext context)
        {
            _context = context;
        }

        // GET: api/Fuentes
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Fuente>>> GetFuentes()
        {
            return await _context.Fuentes.ToListAsync();
        }

        // GET: api/Fuentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fuente>> GetFuente(int id)
        {
            var fuente = await _context.Fuentes.FindAsync(id);

            if (fuente == null)
            {
                return NotFound();
            }

            return fuente;
        }

        // PUT: api/Fuentes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuente(int id, Fuente fuente)
        {
            if (id != fuente.FuenteId)
            {
                return BadRequest();
            }

            _context.Entry(fuente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuenteExists(id))
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

        // POST: api/Fuentes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fuente>> PostFuente(Fuente fuente)
        {
            _context.Fuentes.Add(fuente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFuente", new { id = fuente.FuenteId }, fuente);
        }

        // DELETE: api/Fuentes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuente(int id)
        {
            var fuente = await _context.Fuentes.FindAsync(id);
            if (fuente == null)
            {
                return NotFound();
            }

            _context.Fuentes.Remove(fuente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FuenteExists(int id)
        {
            return _context.Fuentes.Any(e => e.FuenteId == id);
        }
    }
}

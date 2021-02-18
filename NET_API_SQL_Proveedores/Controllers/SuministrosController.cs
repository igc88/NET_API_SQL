using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NET_API_SQL_Proveedores.Models;

namespace NET_API_SQL_Proveedores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuministrosController : ControllerBase
    {
        private readonly APIContext _context;

        public SuministrosController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Suministros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Suministro>>> GetAsignaciones()
        {
            return await _context.Asignaciones.ToListAsync();
        }

        // GET: api/Suministros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Suministro>> GetSuministro(int id)
        {
            var suministro = await _context.Asignaciones.FindAsync(id);

            if (suministro == null)
            {
                return NotFound();
            }

            return suministro;
        }

        // PUT: api/Suministros/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuministro(int id, Suministro suministro)
        {
            if (id != suministro.CodigoPieza)
            {
                return BadRequest();
            }

            _context.Entry(suministro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuministroExists(id))
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

        // POST: api/Suministros
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Suministro>> PostSuministro(Suministro suministro)
        {
            _context.Asignaciones.Add(suministro);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SuministroExists(suministro.CodigoPieza))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSuministro", new { id = suministro.CodigoPieza }, suministro);
        }

        // DELETE: api/Suministros/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Suministro>> DeleteSuministro(int id)
        {
            var suministro = await _context.Asignaciones.FindAsync(id);
            if (suministro == null)
            {
                return NotFound();
            }

            _context.Asignaciones.Remove(suministro);
            await _context.SaveChangesAsync();

            return suministro;
        }

        private bool SuministroExists(int id)
        {
            return _context.Asignaciones.Any(e => e.CodigoPieza == id);
        }
    }
}

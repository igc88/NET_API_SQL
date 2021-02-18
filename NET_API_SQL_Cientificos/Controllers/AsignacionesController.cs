using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NET_API_SQL_Cientificos.Models;

namespace NET_API_SQL_Cientificos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignacionesController : ControllerBase
    {
        private readonly APIContext _context;

        public AsignacionesController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Asignaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asignacion>>> GetAsignaciones()
        {
            return await _context.Asignaciones.ToListAsync();
        }

        // GET: api/Asignaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Asignacion>> GetAsignacion(string id)
        {
            var asignacion = await _context.Asignaciones.FindAsync(id);

            if (asignacion == null)
            {
                return NotFound();
            }

            return asignacion;
        }

        // PUT: api/Asignaciones/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsignacion(string id, Asignacion asignacion)
        {
            if (id != asignacion.CientificoDNI)
            {
                return BadRequest();
            }

            _context.Entry(asignacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsignacionExists(id))
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

        // POST: api/Asignaciones
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Asignacion>> PostAsignacion(Asignacion asignacion)
        {
            _context.Asignaciones.Add(asignacion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AsignacionExists(asignacion.CientificoDNI))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAsignacion", new { id = asignacion.CientificoDNI }, asignacion);
        }

        // DELETE: api/Asignaciones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Asignacion>> DeleteAsignacion(string id)
        {
            var asignacion = await _context.Asignaciones.FindAsync(id);
            if (asignacion == null)
            {
                return NotFound();
            }

            _context.Asignaciones.Remove(asignacion);
            await _context.SaveChangesAsync();

            return asignacion;
        }

        private bool AsignacionExists(string id)
        {
            return _context.Asignaciones.Any(e => e.CientificoDNI == id);
        }
    }
}

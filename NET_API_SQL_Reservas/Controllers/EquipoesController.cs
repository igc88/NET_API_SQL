using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NET_API_SQL_Reservas.Models;

namespace NET_API_SQL_Reservas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoesController : ControllerBase
    {
        private readonly APIContext _context;

        public EquipoesController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Equipoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipo>>> GetEquipos()
        {
            return await _context.Equipos.ToListAsync();
        }

        // GET: api/Equipoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Equipo>> GetEquipo(char id)
        {
            var equipo = await _context.Equipos.FindAsync(id);

            if (equipo == null)
            {
                return NotFound();
            }

            return equipo;
        }

        // PUT: api/Equipoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipo(char id, Equipo equipo)
        {
            if (id != equipo.NumSerie)
            {
                return BadRequest();
            }

            _context.Entry(equipo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipoExists(id))
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

        // POST: api/Equipoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Equipo>> PostEquipo(Equipo equipo)
        {
            _context.Equipos.Add(equipo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipo", new { id = equipo.NumSerie }, equipo);
        }

        // DELETE: api/Equipoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Equipo>> DeleteEquipo(char id)
        {
            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo == null)
            {
                return NotFound();
            }

            _context.Equipos.Remove(equipo);
            await _context.SaveChangesAsync();

            return equipo;
        }

        private bool EquipoExists(char id)
        {
            return _context.Equipos.Any(e => e.NumSerie == id);
        }
    }
}

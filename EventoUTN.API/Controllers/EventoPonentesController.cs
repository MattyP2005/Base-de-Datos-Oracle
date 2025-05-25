using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventosUTN;
using NuGet.ProjectModel;

namespace EventoUTN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoPonentesController : ControllerBase
    {
        private readonly AppContext _context;

        public EventoPonentesController(AppContext context)
        {
            _context = context;
        }

        // GET: api/EventoPonentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventoPonentes>>> GetEventoPonentes()
        {
            var data = await _context.EventoPonentes
                .Include(i => i.IdEvento)
                .Include(i => i.IdPonentes)
                .ToListAsync();
            return data;
        }

        // GET: api/EventoPonentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventoPonentes>> GetEventoPonentes(int id)
        {
            var eventoPonentes = await _context.EventoPonentes.FindAsync(id);

            if (eventoPonentes == null)
            {
                return NotFound();
            }

            return eventoPonentes;
        }

        // PUT: api/EventoPonentes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventoPonentes(int id, EventoPonentes eventoPonentes)
        {
            if (id != eventoPonentes.IdEventoPonentes)
            {
                return BadRequest();
            }

            _context.Entry(eventoPonentes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoPonentesExists(id))
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

        // POST: api/EventoPonentes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EventoPonentes>> PostEventoPonentes(EventoPonentes eventoPonentes)
        {
            _context.EventoPonentes.Add(eventoPonentes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventoPonentes", new { id = eventoPonentes.IdEventoPonentes }, eventoPonentes);
        }

        // DELETE: api/EventoPonentes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventoPonentes(int id)
        {
            var eventoPonentes = await _context.EventoPonentes.FindAsync(id);
            if (eventoPonentes == null)
            {
                return NotFound();
            }

            _context.EventoPonentes.Remove(eventoPonentes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventoPonentesExists(int id)
        {
            return _context.EventoPonentes.Any(e => e.IdEventoPonentes == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventosUTN;

namespace EventoUTN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificadosController : ControllerBase
    {
        private readonly AppContext _context;

        public CertificadosController(AppContext context)
        {
            _context = context;
        }

        // GET: api/Certificados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Certificados>>> GetCertificados()
        {
            var data = await _context.Certificados
                .Include(i => i.IdInscripcion)
                .ToListAsync();
            return data;
        }

        // GET: api/Certificados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Certificados>> GetCertificados(int id)
        {
            var certificados = await _context.Certificados.FindAsync(id);

            if (certificados == null)
            {
                return NotFound();
            }

            return certificados;
        }

        // PUT: api/Certificados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCertificados(int id, Certificados certificados)
        {
            if (id != certificados.IdCertificado)
            {
                return BadRequest();
            }

            _context.Entry(certificados).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CertificadosExists(id))
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

        // POST: api/Certificados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Certificados>> PostCertificados(Certificados certificados)
        {
            _context.Certificados.Add(certificados);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCertificados", new { id = certificados.IdCertificado }, certificados);
        }

        // DELETE: api/Certificados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCertificados(int id)
        {
            var certificados = await _context.Certificados.FindAsync(id);
            if (certificados == null)
            {
                return NotFound();
            }

            _context.Certificados.Remove(certificados);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CertificadosExists(int id)
        {
            return _context.Certificados.Any(e => e.IdCertificado == id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentManager.Server.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentManager.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContratoController : ControllerBase
    {
        private readonly AluguelContext _context;

        public ContratoController(AluguelContext context)
        {
            _context = context;
        }

        // GET: api/Contrato
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contrato>>> GetContratos()
        {
            return Ok(await _context.Contratos
                .Include(c => c.Inquilino)
                .Include(c => c.Propriedade)
                .ToListAsync());
        }

        // GET: api/Contrato/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contrato>> GetContrato(int id)
        {
            var contrato = await _context.Contratos
                .Include(c => c.Inquilino)
                .Include(c => c.Propriedade)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (contrato == null)
            {
                return NotFound();
            }

            return Ok(contrato);
        }

        // POST: api/Contrato
        [HttpPost]
        public async Task<ActionResult<Contrato>> PostContrato(Contrato contrato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Contratos.Add(contrato);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetContrato), new { id = contrato.Id }, contrato);
        }

        // PUT: api/Contrato/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContrato(int id, Contrato contrato)
        {
            if (id != contrato.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(contrato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Contratos.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Contrato/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContrato(int id)
        {
            var contrato = await _context.Contratos.FindAsync(id);
            if (contrato == null)
            {
                return NotFound();
            }

            _context.Contratos.Remove(contrato);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

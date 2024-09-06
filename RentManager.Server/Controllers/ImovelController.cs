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
    public class ImovelController : ControllerBase
    {
        private readonly AluguelContext _context;

        public ImovelController(AluguelContext context)
        {
            _context = context;
        }

        // GET: api/Imovel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Imovel>>> GetImoveis()
        {
            return Ok(await _context.Imoveis
                .Include(i => i.Locador)
                .ToListAsync());
        }

        // GET: api/Imovel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Imovel>> GetImovel(int id)
        {
            var imovel = await _context.Imoveis
                .Include(i => i.Locador)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (imovel == null)
            {
                return NotFound();
            }

            return Ok(imovel);
        }

        // POST: api/Imovel
        [HttpPost]
        public async Task<ActionResult<Imovel>> PostImovel(Imovel imovel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Imoveis.Add(imovel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetImovel), new { id = imovel.Id }, imovel);
        }

        // PUT: api/Imovel/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImovel(int id, Imovel imovel)
        {
            if (id != imovel.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(imovel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Imoveis.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Imovel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImovel(int id)
        {
            var imovel = await _context.Imoveis.FindAsync(id);
            if (imovel == null)
            {
                return NotFound();
            }

            _context.Imoveis.Remove(imovel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

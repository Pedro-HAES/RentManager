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
    public class PagamentoController : ControllerBase
    {
        private readonly AluguelContext _context;

        public PagamentoController(AluguelContext context)
        {
            _context = context;
        }

        // GET: api/Pagamento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pagamento>>> GetPagamentos()
        {
            return Ok(await _context.Pagamentos
                .Include(p => p.Contrato)
                .ToListAsync());
        }

        // GET: api/Pagamento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pagamento>> GetPagamento(int id)
        {
            var pagamento = await _context.Pagamentos
                .Include(p => p.Contrato)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (pagamento == null)
            {
                return NotFound();
            }

            return Ok(pagamento);
        }

        // POST: api/Pagamento
        [HttpPost]
        public async Task<ActionResult<Pagamento>> PostPagamento(Pagamento pagamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Pagamentos.Add(pagamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPagamento), new { id = pagamento.Id }, pagamento);
        }

        // PUT: api/Pagamento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPagamento(int id, Pagamento pagamento)
        {
            if (id != pagamento.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(pagamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Pagamentos.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Pagamento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePagamento(int id)
        {
            var pagamento = await _context.Pagamentos.FindAsync(id);
            if (pagamento == null)
            {
                return NotFound();
            }

            _context.Pagamentos.Remove(pagamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreGarageFinancialPendency.Data;
using Models;
using Models.DTO;

namespace AndreGarageFinancialPendency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialPendenciesController : ControllerBase
    {
        private readonly AndreGarageFinancialPendencyContext _context;
        

        public FinancialPendenciesController(AndreGarageFinancialPendencyContext context)
        {
            _context = context;
        }

        // GET: api/FinancialPendencies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinancialPendency>>> GetFinancialPendency()
        {
          if (_context.FinancialPendency == null)
          {
              return NotFound();
          }
            return await _context.FinancialPendency.Include(c => c.Client).Include(a => a.Client.Adress).ToListAsync();
        }

        // GET: api/FinancialPendencies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FinancialPendency>> GetFinancialPendency(int id)
        {
          if (_context.FinancialPendency == null)
          {
              return NotFound();
          }
            var financialPendency = await _context.FinancialPendency.Include(c => c.Client).Include(a => a.Client.Adress).SingleOrDefaultAsync(f => f.Id == id);

            if (financialPendency == null)
            {
                return NotFound();
            }

            return financialPendency;
        }

        // PUT: api/FinancialPendencies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinancialPendency(int id, FinancialPendency financialPendency)
        {
            if (id != financialPendency.Id)
            {
                return BadRequest();
            }

            _context.Entry(financialPendency).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinancialPendencyExists(id))
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

        // POST: api/FinancialPendencies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FinancialPendency>> PostFinancialPendency(FinancialPendencyDTO dTO)
        {
           
            var client = await _context.Client.FindAsync(dTO.DocumentClient);
            var financialPendency = new FinancialPendency(dTO, client);
         
            _context.FinancialPendency.Add(financialPendency);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFinancialPendency", new { id = financialPendency.Id }, financialPendency);
        }

        // DELETE: api/FinancialPendencies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFinancialPendency(int id)
        {
            if (_context.FinancialPendency == null)
            {
                return NotFound();
            }
            var financialPendency = await _context.FinancialPendency.FindAsync(id);
            if (financialPendency == null)
            {
                return NotFound();
            }

            _context.FinancialPendency.Remove(financialPendency);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FinancialPendencyExists(int id)
        {
            return (_context.FinancialPendency?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

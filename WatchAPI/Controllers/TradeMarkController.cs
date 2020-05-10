using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchAPI.Model;

namespace WatchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradeMarkController : ControllerBase
    {
        private readonly WatchDBContext _context;

        public TradeMarkController(WatchDBContext context)
        {
            _context = context;
        }

        // GET: api/TradeMark
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TradeMark>>> GetTradeMark()
        {
            return await _context.TradeMark.ToListAsync();
        }

        // GET: api/TradeMark/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TradeMark>> GetTradeMark(int id)
        {
            var tradeMark = await _context.TradeMark.FindAsync(id);

            if (tradeMark == null)
            {
                return NotFound();
            }

            return tradeMark;
        }

        // PUT: api/TradeMark/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTradeMark(int id, TradeMark tradeMark)
        {
            if (id != tradeMark.TradeMarkId)
            {
                return BadRequest();
            }

            _context.Entry(tradeMark).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TradeMarkExists(id))
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

        // POST: api/TradeMark
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TradeMark>> PostTradeMark(TradeMark tradeMark)
        {
            _context.TradeMark.Add(tradeMark);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTradeMark", new { id = tradeMark.TradeMarkId }, tradeMark);
        }

        // DELETE: api/TradeMark/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TradeMark>> DeleteTradeMark(int id)
        {
            var tradeMark = await _context.TradeMark.FindAsync(id);
            if (tradeMark == null)
            {
                return NotFound();
            }

            _context.TradeMark.Remove(tradeMark);
            await _context.SaveChangesAsync();

            return tradeMark;
        }

        private bool TradeMarkExists(int id)
        {
            return _context.TradeMark.Any(e => e.TradeMarkId == id);
        }
    }
}

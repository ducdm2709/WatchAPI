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
    public class TopSellController : ControllerBase
    {
        private readonly WatchDBContext _context;

        public TopSellController(WatchDBContext context)
        {
            _context = context;
        }

        // GET: api/TopSell
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TopSell>>> GetTopSell()
        {
            return await _context.TopSell.ToListAsync();
        }

        // GET: api/TopSell/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TopSell>> GetTopSell(int id)
        {
            var topSell = await _context.TopSell.FindAsync(id);

            if (topSell == null)
            {
                return NotFound();
            }

            return topSell;
        }

        // PUT: api/TopSell/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTopSell(int id, TopSell topSell)
        {
            if (id != topSell.TopSellId)
            {
                return BadRequest();
            }

            _context.Entry(topSell).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TopSellExists(id))
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

        // POST: api/TopSell
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TopSell>> PostTopSell(TopSell topSell)
        {
            _context.TopSell.Add(topSell);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTopSell", new { id = topSell.TopSellId }, topSell);
        }

        // DELETE: api/TopSell/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TopSell>> DeleteTopSell(int id)
        {
            var topSell = await _context.TopSell.FindAsync(id);
            if (topSell == null)
            {
                return NotFound();
            }

            _context.TopSell.Remove(topSell);
            await _context.SaveChangesAsync();

            return topSell;
        }

        private bool TopSellExists(int id)
        {
            return _context.TopSell.Any(e => e.TopSellId == id);
        }
    }
}

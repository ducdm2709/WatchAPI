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
    public class InfoAccountController : ControllerBase
    {
        private readonly WatchDBContext _context;

        public InfoAccountController(WatchDBContext context)
        {
            _context = context;
        }

        // GET: api/InfoAccount
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InfoAccount>>> GetInfoAccount()
        {
            return await _context.InfoAccount.ToListAsync();
        }

        // GET: api/InfoAccount/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InfoAccount>> GetInfoAccount(int id)
        {
            var infoAccount = await _context.InfoAccount.FindAsync(id);

            if (infoAccount == null)
            {
                return NotFound();
            }

            return infoAccount;
        }

        // PUT: api/InfoAccount/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInfoAccount(int id, InfoAccount infoAccount)
        {
            if (id != infoAccount.InfoAccountId)
            {
                return BadRequest();
            }

            _context.Entry(infoAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfoAccountExists(id))
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

        // POST: api/InfoAccount
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<InfoAccount>> PostInfoAccount(InfoAccount infoAccount)
        {
            _context.InfoAccount.Add(infoAccount);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInfoAccount", new { id = infoAccount.InfoAccountId }, infoAccount);
        }

        // DELETE: api/InfoAccount/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InfoAccount>> DeleteInfoAccount(int id)
        {
            var infoAccount = await _context.InfoAccount.FindAsync(id);
            if (infoAccount == null)
            {
                return NotFound();
            }

            _context.InfoAccount.Remove(infoAccount);
            await _context.SaveChangesAsync();

            return infoAccount;
        }

        private bool InfoAccountExists(int id)
        {
            return _context.InfoAccount.Any(e => e.InfoAccountId == id);
        }
    }
}

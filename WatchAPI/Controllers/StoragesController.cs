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
    public class StoragesController : ControllerBase
    {
        private readonly WatchDBContext _context;

        public StoragesController(WatchDBContext context)
        {
            _context = context;
        }

        // GET: api/Storages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Storages>>> GetStorages()
        {
            return await _context.Storages.ToListAsync();
        }

        // GET: api/Storages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Storages>> GetStorages(int id)
        {
            var storages = await _context.Storages.FindAsync(id);

            if (storages == null)
            {
                return NotFound();
            }

            return storages;
        }

        // PUT: api/Storages/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStorages(int id, Storages storages)
        {
            if (id != storages.StorageId)
            {
                return BadRequest();
            }

            _context.Entry(storages).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoragesExists(id))
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

        // POST: api/Storages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Storages>> PostStorages(Storages storages)
        {
            _context.Storages.Add(storages);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStorages", new { id = storages.StorageId }, storages);
        }

        // DELETE: api/Storages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Storages>> DeleteStorages(int id)
        {
            var storages = await _context.Storages.FindAsync(id);
            if (storages == null)
            {
                return NotFound();
            }

            _context.Storages.Remove(storages);
            await _context.SaveChangesAsync();

            return storages;
        }

        private bool StoragesExists(int id)
        {
            return _context.Storages.Any(e => e.StorageId == id);
        }
    }
}

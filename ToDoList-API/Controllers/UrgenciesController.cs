using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList_API;
using ToDoList_DAL;

namespace ToDoList_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrgenciesController : ControllerBase
    {
        private readonly todolistContext _context;

        public UrgenciesController(todolistContext context)
        {
            _context = context;
        }

        // GET: api/Urgencies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Urgency>>> GetUrgencies()
        {
            return await _context.Urgencies.ToListAsync();
        }

        // GET: api/Urgencies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Urgency>> GetUrgency(int id)
        {
            var urgency = await _context.Urgencies.FindAsync(id);

            if (urgency == null)
            {
                return NotFound();
            }

            return urgency;
        }

        // PUT: api/Urgencies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUrgency(int id, Urgency urgency)
        {
            if (id != urgency.UrgencyId)
            {
                return BadRequest();
            }

            _context.Entry(urgency).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UrgencyExists(id))
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

        // POST: api/Urgencies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Urgency>> PostUrgency(Urgency urgency)
        {
            _context.Urgencies.Add(urgency);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUrgency", new { id = urgency.UrgencyId }, urgency);
        }

        // DELETE: api/Urgencies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUrgency(int id)
        {
            var urgency = await _context.Urgencies.FindAsync(id);
            if (urgency == null)
            {
                return NotFound();
            }

            _context.Urgencies.Remove(urgency);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UrgencyExists(int id)
        {
            return _context.Urgencies.Any(e => e.UrgencyId == id);
        }
    }
}

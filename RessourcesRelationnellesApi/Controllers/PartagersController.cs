using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RessourcesRelationnellesAPI.Models;

namespace RessourcesRelationnellesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartagersController : ControllerBase
    {
        private readonly DataContext _context;

        public PartagersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Partagers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Partager>>> GetPartager()
        {
            return await _context.Partager.ToListAsync();
        }

        // GET: api/Partagers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Partager>> GetPartager(uint id)
        {
            var partager = await _context.Partager.FindAsync(id);

            if (partager == null)
            {
                return NotFound();
            }

            return partager;
        }

        // PUT: api/Partagers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartager(uint id, Partager partager)
        {
            if (id != partager.id_Partager)
            {
                return BadRequest();
            }

            _context.Entry(partager).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartagerExists(id))
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

        // POST: api/Partagers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Partager>> PostPartager(Partager partager)
        {
            _context.Partager.Add(partager);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPartager", new { id = partager.id_Partager }, partager);
        }

        // DELETE: api/Partagers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartager(uint id)
        {
            var partager = await _context.Partager.FindAsync(id);
            if (partager == null)
            {
                return NotFound();
            }

            _context.Partager.Remove(partager);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PartagerExists(uint id)
        {
            return _context.Partager.Any(e => e.id_Partager == id);
        }
    }
}

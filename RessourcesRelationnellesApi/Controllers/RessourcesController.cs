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
    public class RessourcesController : ControllerBase
    {
        private readonly DataContext _context;

        public RessourcesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Ressources
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ressources>>> GetRessources()
        {
            return await _context.Ressources.ToListAsync();
        }

        // GET: api/Ressources/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ressources>> GetRessources(uint id)
        {
            var ressources = await _context.Ressources.FindAsync(id);

            if (ressources == null)
            {
                return NotFound();
            }

            return ressources;
        }

        // PUT: api/Ressources/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRessources(uint id, Ressources ressources)
        {
            if (id != ressources.id_ressource)
            {
                return BadRequest();
            }

            _context.Entry(ressources).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RessourcesExists(id))
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

        // POST: api/Ressources
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ressources>> PostRessources(Ressources ressources)
        {
            _context.Ressources.Add(ressources);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRessources", new { id = ressources.id_ressource }, ressources);
        }

        // DELETE: api/Ressources/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRessources(uint id)
        {
            var ressources = await _context.Ressources.FindAsync(id);
            if (ressources == null)
            {
                return NotFound();
            }

            _context.Ressources.Remove(ressources);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RessourcesExists(uint id)
        {
            return _context.Ressources.Any(e => e.id_ressource == id);
        }
    }
}

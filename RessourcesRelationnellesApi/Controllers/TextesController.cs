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
    public class TextesController : ControllerBase
    {
        private readonly DataContext _context;

        public TextesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Textes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Texte>>> GetTextes()
        {
            return await _context.Textes.ToListAsync();
        }

        // GET: api/Textes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Texte>> GetTexte(uint id)
        {
            var texte = await _context.Textes.FindAsync(id);

            if (texte == null)
            {
                return NotFound();
            }

            return texte;
        }

        // PUT: api/Textes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTexte(uint id, Texte texte)
        {
            if (id != texte.id_ressource)
            {
                return BadRequest();
            }

            _context.Entry(texte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TexteExists(id))
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

        // POST: api/Textes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Texte>> PostTexte(Texte texte)
        {
            _context.Textes.Add(texte);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTexte", new { id = texte.id_ressource }, texte);
        }

        // DELETE: api/Textes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTexte(uint id)
        {
            var texte = await _context.Textes.FindAsync(id);
            if (texte == null)
            {
                return NotFound();
            }

            _context.Textes.Remove(texte);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TexteExists(uint id)
        {
            return _context.Textes.Any(e => e.id_ressource == id);
        }
    }
}

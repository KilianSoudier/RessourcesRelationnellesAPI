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
    public class Categorie_RessourceController : ControllerBase
    {
        private readonly DataContext _context;

        public Categorie_RessourceController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Categorie_Ressource
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categorie_Ressource>>> GetCategorie_Ressources()
        {
            return await _context.Categorie_Ressources.ToListAsync();
        }

        // GET: api/Categorie_Ressource/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categorie_Ressource>> GetCategorie_Ressource(int id)
        {
            var categorie_Ressource = await _context.Categorie_Ressources.FindAsync(id);

            if (categorie_Ressource == null)
            {
                return NotFound();
            }

            return categorie_Ressource;
        }

        // PUT: api/Categorie_Ressource/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategorie_Ressource(int id, Categorie_Ressource categorie_Ressource)
        {
            if (id != categorie_Ressource.id_categorie)
            {
                return BadRequest();
            }

            _context.Entry(categorie_Ressource).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Categorie_RessourceExists(id))
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

        // POST: api/Categorie_Ressource
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Categorie_Ressource>> PostCategorie_Ressource(Categorie_Ressource categorie_Ressource)
        {
            _context.Categorie_Ressources.Add(categorie_Ressource);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategorie_Ressource", new { id = categorie_Ressource.id_categorie }, categorie_Ressource);
        }

        // DELETE: api/Categorie_Ressource/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategorie_Ressource(int id)
        {
            var categorie_Ressource = await _context.Categorie_Ressources.FindAsync(id);
            if (categorie_Ressource == null)
            {
                return NotFound();
            }

            _context.Categorie_Ressources.Remove(categorie_Ressource);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Categorie_RessourceExists(int id)
        {
            return _context.Categorie_Ressources.Any(e => e.id_categorie == id);
        }
    }
}

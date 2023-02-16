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
    public class Trier_Ressources_CategoriesController : ControllerBase
    {
        private readonly DataContext _context;

        public Trier_Ressources_CategoriesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Trier_Ressources_Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trier_Ressources_Categories>>> GetTrier_Ressources_Categories()
        {
            return await _context.Trier_Ressources_Categories.ToListAsync();
        }

        // GET: api/Trier_Ressources_Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trier_Ressources_Categories>> GetTrier_Ressources_Categories(int id)
        {
            var trier_Ressources_Categories = await _context.Trier_Ressources_Categories.FindAsync(id);

            if (trier_Ressources_Categories == null)
            {
                return NotFound();
            }

            return trier_Ressources_Categories;
        }

        // PUT: api/Trier_Ressources_Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrier_Ressources_Categories(int id, Trier_Ressources_Categories trier_Ressources_Categories)
        {
            if (id != trier_Ressources_Categories.id_trier_categories)
            {
                return BadRequest();
            }

            _context.Entry(trier_Ressources_Categories).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Trier_Ressources_CategoriesExists(id))
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

        // POST: api/Trier_Ressources_Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trier_Ressources_Categories>> PostTrier_Ressources_Categories(Trier_Ressources_Categories trier_Ressources_Categories)
        {
            _context.Trier_Ressources_Categories.Add(trier_Ressources_Categories);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrier_Ressources_Categories", new { id = trier_Ressources_Categories.id_trier_categories }, trier_Ressources_Categories);
        }

        // DELETE: api/Trier_Ressources_Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrier_Ressources_Categories(int id)
        {
            var trier_Ressources_Categories = await _context.Trier_Ressources_Categories.FindAsync(id);
            if (trier_Ressources_Categories == null)
            {
                return NotFound();
            }

            _context.Trier_Ressources_Categories.Remove(trier_Ressources_Categories);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Trier_Ressources_CategoriesExists(int id)
        {
            return _context.Trier_Ressources_Categories.Any(e => e.id_trier_categories == id);
        }
    }
}

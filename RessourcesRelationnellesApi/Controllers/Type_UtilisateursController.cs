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
    public class Type_UtilisateursController : ControllerBase
    {
        private readonly DataContext _context;

        public Type_UtilisateursController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Type_Utilisateurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Type_Utilisateurs>>> GetType_Utilisateurs()
        {
            return await _context.Type_Utilisateurs.ToListAsync();
        }

        // GET: api/Type_Utilisateurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Type_Utilisateurs>> GetType_Utilisateurs(int id)
        {
            var type_Utilisateurs = await _context.Type_Utilisateurs.FindAsync(id);

            if (type_Utilisateurs == null)
            {
                return NotFound();
            }

            return type_Utilisateurs;
        }

        // PUT: api/Type_Utilisateurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutType_Utilisateurs(int id, Type_Utilisateurs type_Utilisateurs)
        {
            if (id != type_Utilisateurs.id_type_user)
            {
                return BadRequest();
            }

            _context.Entry(type_Utilisateurs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Type_UtilisateursExists(id))
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

        // POST: api/Type_Utilisateurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Type_Utilisateurs>> PostType_Utilisateurs(Type_Utilisateurs type_Utilisateurs)
        {
            _context.Type_Utilisateurs.Add(type_Utilisateurs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetType_Utilisateurs", new { id = type_Utilisateurs.id_type_user }, type_Utilisateurs);
        }

        // DELETE: api/Type_Utilisateurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteType_Utilisateurs(int id)
        {
            var type_Utilisateurs = await _context.Type_Utilisateurs.FindAsync(id);
            if (type_Utilisateurs == null)
            {
                return NotFound();
            }

            _context.Type_Utilisateurs.Remove(type_Utilisateurs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Type_UtilisateursExists(int id)
        {
            return _context.Type_Utilisateurs.Any(e => e.id_type_user == id);
        }
    }
}

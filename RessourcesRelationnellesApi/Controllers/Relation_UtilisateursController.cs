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
    public class Relation_UtilisateursController : ControllerBase
    {
        private readonly DataContext _context;

        public Relation_UtilisateursController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Relation_Utilisateurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Relation_Utilisateurs>>> GetRelation_Utilisateurs()
        {
            return await _context.Relation_Utilisateurs.ToListAsync();
        }

        // GET: api/Relation_Utilisateurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Relation_Utilisateurs>> GetRelation_Utilisateurs(uint id)
        {
            var relation_Utilisateurs = await _context.Relation_Utilisateurs.FindAsync(id);

            if (relation_Utilisateurs == null)
            {
                return NotFound();
            }

            return relation_Utilisateurs;
        }

        // PUT: api/Relation_Utilisateurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRelation_Utilisateurs(uint id, Relation_Utilisateurs relation_Utilisateurs)
        {
            if (id != relation_Utilisateurs.id_Relation_Utilisateurs)
            {
                return BadRequest();
            }

            _context.Entry(relation_Utilisateurs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Relation_UtilisateursExists(id))
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

        // POST: api/Relation_Utilisateurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Relation_Utilisateurs>> PostRelation_Utilisateurs(Relation_Utilisateurs relation_Utilisateurs)
        {
            _context.Relation_Utilisateurs.Add(relation_Utilisateurs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRelation_Utilisateurs", new { id = relation_Utilisateurs.id_Relation_Utilisateurs }, relation_Utilisateurs);
        }

        // DELETE: api/Relation_Utilisateurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRelation_Utilisateurs(uint id)
        {
            var relation_Utilisateurs = await _context.Relation_Utilisateurs.FindAsync(id);
            if (relation_Utilisateurs == null)
            {
                return NotFound();
            }

            _context.Relation_Utilisateurs.Remove(relation_Utilisateurs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Relation_UtilisateursExists(uint id)
        {
            return _context.Relation_Utilisateurs.Any(e => e.id_Relation_Utilisateurs == id);
        }
    }
}

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
    public class UtilisateursController : ControllerBase
    {
        private readonly DataContext _context;

        public UtilisateursController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Utilisateurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Utilisateurs>>> GetUtilisateurs()
        {
            return await _context.Utilisateurs.ToListAsync();
        }
        // GET: api/Utilisateurs/modo
        [HttpGet("modo")]
        public async Task<ActionResult<IEnumerable<Utilisateurs>>> GetModo()
        {
            Type_Utilisateurs modo = new Type_Utilisateurs();
            modo.id_type_user = 3;
            modo.nom = "moderateur";
            return await _context.Utilisateurs.Where(s => s.Type_Utilisateur == modo).ToListAsync();
        }

        // GET: api/Utilisateurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Utilisateurs>> GetUtilisateurs(uint id)
        {
            var utilisateurs = await _context.Utilisateurs.FindAsync(id);

            if (utilisateurs == null)
            {
                return NotFound();
            }

            return utilisateurs;
        }

        // GET: /api/Utilisateurs/a@mail.com, aa
        [HttpGet("{mail}, {mdp}")]
        public async Task<ActionResult<Utilisateurs>> GetUtilisateurs(string mail, string mdp)
        {
            var utilisateurs = await _context.Utilisateurs.FirstOrDefaultAsync(s=>s.email==mail && s.mdp==mdp);

            if (utilisateurs == null)
            {
                return NotFound();
            }

            return utilisateurs;
        }

        // PATCH: api/Utilisateurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchUtilisateurs(uint id, Utilisateurs utilisateurs)
        {
            if (id != utilisateurs.id_user)
            {
                return BadRequest();
            }

            _context.Entry(utilisateurs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UtilisateursExists(id))
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

        // POST: api/Utilisateurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Utilisateurs>> PostUtilisateurs(Utilisateurs utilisateurs)
        {
            _context.Utilisateurs.Add(utilisateurs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUtilisateurs", new { id = utilisateurs.id_user }, utilisateurs);
        }

        // DELETE: api/Utilisateurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUtilisateurs(uint id)
        {
            var utilisateurs = await _context.Utilisateurs.FindAsync(id);
            if (utilisateurs == null)
            {
                return NotFound();
            }

            _context.Utilisateurs.Remove(utilisateurs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UtilisateursExists(uint id)
        {
            return _context.Utilisateurs.Any(e => e.id_user == id);
        }
    }
}

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
    public class Type_RelationController : ControllerBase
    {
        private readonly DataContext _context;

        public Type_RelationController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Type_Relation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Type_Relation>>> GetType_Relations()
        {
            return await _context.Type_Relations.ToListAsync();
        }

        // GET: api/Type_Relation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Type_Relation>> GetType_Relation(int id)
        {
            var type_Relation = await _context.Type_Relations.FindAsync(id);

            if (type_Relation == null)
            {
                return NotFound();
            }

            return type_Relation;
        }

        // PUT: api/Type_Relation/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutType_Relation(int id, Type_Relation type_Relation)
        {
            if (id != type_Relation.id_Type_Relation)
            {
                return BadRequest();
            }

            _context.Entry(type_Relation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Type_RelationExists(id))
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

        // POST: api/Type_Relation
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Type_Relation>> PostType_Relation(Type_Relation type_Relation)
        {
            _context.Type_Relations.Add(type_Relation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetType_Relation", new { id = type_Relation.id_Type_Relation }, type_Relation);
        }

        // DELETE: api/Type_Relation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteType_Relation(int id)
        {
            var type_Relation = await _context.Type_Relations.FindAsync(id);
            if (type_Relation == null)
            {
                return NotFound();
            }

            _context.Type_Relations.Remove(type_Relation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Type_RelationExists(int id)
        {
            return _context.Type_Relations.Any(e => e.id_Type_Relation == id);
        }
    }
}

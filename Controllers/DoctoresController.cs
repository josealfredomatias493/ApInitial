using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApInitial.Models;

namespace ApInitial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctoresController : ControllerBase
    {
        private readonly CITASMEDICASContext _context;

        public DoctoresController(CITASMEDICASContext context)
        {
            _context = context;
        }

        // GET: api/Doctores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctore>>> GetDoctores()
        {
            return await _context.Doctores.ToListAsync();
        }

        // GET: api/Doctores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctore>> GetDoctore(int id)
        {
            var doctore = await _context.Doctores.FindAsync(id);

            if (doctore == null)
            {
                return NotFound();
            }

            return doctore;
        }

        // PUT: api/Doctores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctore(int id, Doctore doctore)
        {
            if (id != doctore.DocCodigo)
            {
                return BadRequest();
            }

            _context.Entry(doctore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctoreExists(id))
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

        // POST: api/Doctores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Doctore>> PostDoctore(Doctore doctore)
        {
            _context.Doctores.Add(doctore);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DoctoreExists(doctore.DocCodigo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDoctore", new { id = doctore.DocCodigo }, doctore);
        }

        // DELETE: api/Doctores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctore(int id)
        {
            var doctore = await _context.Doctores.FindAsync(id);
            if (doctore == null)
            {
                return NotFound();
            }

            _context.Doctores.Remove(doctore);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DoctoreExists(int id)
        {
            return _context.Doctores.Any(e => e.DocCodigo == id);
        }
    }
}

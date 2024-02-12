using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GrupoBLEficienteAPI.Models;

namespace GrupoBLEficienteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalIdTypesController : ControllerBase
    {
        private readonly GBLContext _context;

        public NationalIdTypesController(GBLContext context)
        {
            _context = context;
        }

        // GET: api/NationalIdTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NationalIdTypes>>> GetNationalIdTypes()
        {
            return await _context.NationalIdTypes.ToListAsync();
        }

        // GET: api/NationalIdTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NationalIdTypes>> GetNationalIdTypes(int id)
        {
            var nationalIdTypes = await _context.NationalIdTypes.FindAsync(id);

            if (nationalIdTypes == null)
            {
                return NotFound();
            }

            return nationalIdTypes;
        }

        // PUT: api/NationalIdTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNationalIdTypes(int id, NationalIdTypes nationalIdTypes)
        {
            if (id != nationalIdTypes.Idtype)
            {
                return BadRequest();
            }

            _context.Entry(nationalIdTypes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NationalIdTypesExists(id))
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

        // POST: api/NationalIdTypes
        [HttpPost]
        public async Task<ActionResult<NationalIdTypes>> PostNationalIdTypes(NationalIdTypes nationalIdTypes)
        {
            _context.NationalIdTypes.Add(nationalIdTypes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNationalIdTypes", new { id = nationalIdTypes.Idtype }, nationalIdTypes);
        }

        // DELETE: api/NationalIdTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNationalIdTypes(int id)
        {
            var nationalIdTypes = await _context.NationalIdTypes.FindAsync(id);
            if (nationalIdTypes == null)
            {
                return NotFound();
            }

            _context.NationalIdTypes.Remove(nationalIdTypes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NationalIdTypesExists(int id)
        {
            return _context.NationalIdTypes.Any(e => e.Idtype == id);
        }
    }
}

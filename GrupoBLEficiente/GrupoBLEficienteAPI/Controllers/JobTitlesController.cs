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
    public class JobTitlesController : ControllerBase
    {
        private readonly GBLContext _context;

        public JobTitlesController(GBLContext context)
        {
            _context = context;
        }

        // GET: api/JobTitles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobTitles>>> GetJobTitles()
        {
            return await _context.JobTitles.ToListAsync();
        }

        // GET: api/JobTitles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobTitles>> GetJobTitles(int id)
        {
            var jobTitles = await _context.JobTitles.FindAsync(id);

            if (jobTitles == null)
            {
                return NotFound();
            }

            return jobTitles;
        }

        // PUT: api/JobTitles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobTitles(int id, JobTitles jobTitles)
        {
            if (id != jobTitles.IdJobTitle)
            {
                return BadRequest();
            }

            _context.Entry(jobTitles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobTitlesExists(id))
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

        // POST: api/JobTitles
        [HttpPost]
        public async Task<ActionResult<JobTitles>> PostJobTitles(JobTitles jobTitles)
        {
            _context.JobTitles.Add(jobTitles);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (JobTitlesExists(jobTitles.IdJobTitle))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetJobTitles", new { id = jobTitles.IdJobTitle }, jobTitles);
        }

        // DELETE: api/JobTitles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobTitles(int id)
        {
            var jobTitles = await _context.JobTitles.FindAsync(id);
            if (jobTitles == null)
            {
                return NotFound();
            }

            _context.JobTitles.Remove(jobTitles);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobTitlesExists(int id)
        {
            return _context.JobTitles.Any(e => e.IdJobTitle == id);
        }
    }
}

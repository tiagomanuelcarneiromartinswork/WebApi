using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllocationsController : ControllerBase
    {
        private readonly WebApiContext _context;

        public AllocationsController(WebApiContext context)
        {
            _context = context;
        }

        // GET: api/Allocations
        [HttpGet]
        public IEnumerable<Allocation> GetAllocation()
        {
            return _context.Allocation;
        }

        // GET: api/Allocations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllocation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var allocation = await _context.Allocation.FindAsync(id);

            if (allocation == null)
            {
                return NotFound();
            }

            return Ok(allocation);
        }

        // PUT: api/Allocations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAllocation([FromRoute] int id, [FromBody] Allocation allocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != allocation.Id)
            {
                return BadRequest();
            }

            _context.Entry(allocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllocationExists(id))
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

        // POST: api/Allocations
        [HttpPost]
        public async Task<IActionResult> PostAllocation([FromBody] Allocation allocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Allocation.Add(allocation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAllocation", new { id = allocation.Id }, allocation);
        }

        // DELETE: api/Allocations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllocation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var allocation = await _context.Allocation.FindAsync(id);
            if (allocation == null)
            {
                return NotFound();
            }

            _context.Allocation.Remove(allocation);
            await _context.SaveChangesAsync();

            return Ok(allocation);
        }

        private bool AllocationExists(int id)
        {
            return _context.Allocation.Any(e => e.Id == id);
        }
    }
}
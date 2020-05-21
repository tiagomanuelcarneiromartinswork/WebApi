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
    public class PlatoonsController : ControllerBase
    {
        private readonly WebApiContext _context;

        public PlatoonsController(WebApiContext context)
        {
            _context = context;
        }

        // GET: api/Platoons
        [HttpGet]
        public IEnumerable<Platoon> GetPlatoon()
        {
            return _context.Platoon;
        }

        // GET: api/Platoons/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlatoon([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var platoon = await _context.Platoon.FindAsync(id);

            if (platoon == null)
            {
                return NotFound();
            }

            return Ok(platoon);
        }

        // PUT: api/Platoons/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlatoon([FromRoute] int id, [FromBody] Platoon platoon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != platoon.Id)
            {
                return BadRequest();
            }

            _context.Entry(platoon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlatoonExists(id))
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

        // POST: api/Platoons
        [HttpPost]
        public async Task<IActionResult> PostPlatoon([FromBody] Platoon platoon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Platoon.Add(platoon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlatoon", new { id = platoon.Id }, platoon);
        }

        // DELETE: api/Platoons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlatoon([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var platoon = await _context.Platoon.FindAsync(id);
            if (platoon == null)
            {
                return NotFound();
            }

            _context.Platoon.Remove(platoon);
            await _context.SaveChangesAsync();

            return Ok(platoon);
        }

        private bool PlatoonExists(int id)
        {
            return _context.Platoon.Any(e => e.Id == id);
        }
    }
}
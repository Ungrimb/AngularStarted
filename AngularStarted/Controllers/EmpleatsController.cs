using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AngularStarted.Models;
using AngularStarted.Data;
using System.Globalization;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

namespace AngularStarted.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]

    public class EmpleatsController : ControllerBase
    {
        private readonly EmpleatContext _context;
        private readonly IData<Empleat> _data;

        public EmpleatsController(EmpleatContext context, IData<Empleat> data)
        {
            _context = context;
            _data = data;
        }

        // GET: api/Empleats
        [HttpGet]
        public IEnumerable<Empleat> Get()
        {
            return _context.Empleats.OrderByDescending(p => p.Id);
        }

        // GET: api/Empleats/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var empleat = await _context.Empleats.FindAsync(id);

            if (empleat == null)
            {
                return NotFound();
            }

            return Ok(empleat);
        }

        // PUT: api/Empleats/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Empleat empleat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empleat.Id)
            {
                return BadRequest();
            }

            _context.Entry(empleat).State = EntityState.Modified;

            try
            {
                _data.Update(empleat);
                var save = await _data.SaveAsync(empleat);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleatExists(id))
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

        // POST: api/Empleats
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Empleat empleat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _data.Add(empleat);
            var save = await _data.SaveAsync(empleat);

            return CreatedAtAction("GetBlogPost", new { id = empleat.Id }, empleat);
        }

        // DELETE: api/Empleats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var empleat = await _context.Empleats.FindAsync(id);
            if (empleat == null)
            {
                return NotFound();
            }

            _data.Delete(empleat);
            var save = await _data.SaveAsync(empleat);

            return Ok(empleat);
        }

        private bool EmpleatExists(long id)
        {
            return _context.Empleats.Any(e => e.Id == id);
        }
    }
}

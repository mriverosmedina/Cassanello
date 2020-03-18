using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cassanello.Web.Datos;
using Cassanello.Web.Datos.Entidades;

namespace Cassanello.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadesController : ControllerBase
    {
        private readonly DataContext _context;

        public EspecialidadesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Especialidades
        [HttpGet]
        public IEnumerable<Especialidad> GetEspecialidades()
        {
            return _context.Especialidades;
        }

        // GET: api/Especialidades/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEspecialidad([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var especialidad = await _context.Especialidades.FindAsync(id);

            if (especialidad == null)
            {
                return NotFound();
            }

            return Ok(especialidad);
        }

        // PUT: api/Especialidades/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEspecialidad([FromRoute] int id, [FromBody] Especialidad especialidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != especialidad.Id)
            {
                return BadRequest();
            }

            _context.Entry(especialidad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EspecialidadExists(id))
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

        // POST: api/Especialidades
        [HttpPost]
        public async Task<IActionResult> PostEspecialidad([FromBody] Especialidad especialidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Especialidades.Add(especialidad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEspecialidad", new { id = especialidad.Id }, especialidad);
        }

        // DELETE: api/Especialidades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEspecialidad([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var especialidad = await _context.Especialidades.FindAsync(id);
            if (especialidad == null)
            {
                return NotFound();
            }

            _context.Especialidades.Remove(especialidad);
            await _context.SaveChangesAsync();

            return Ok(especialidad);
        }

        private bool EspecialidadExists(int id)
        {
            return _context.Especialidades.Any(e => e.Id == id);
        }
    }
}
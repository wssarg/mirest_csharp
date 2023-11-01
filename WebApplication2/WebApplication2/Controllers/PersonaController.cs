
namespace WebApplication2.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using WebApplication2.Data;
    using WebApplication2.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController:ControllerBase
    {
        private readonly ApiDbContext _context;

        public PersonaController(ApiDbContext context)
        {
                _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get() { 
            var personas = await _context.Personas.ToListAsync();
            return Ok(personas);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var persona = await _context.Personas.FirstOrDefaultAsync(x => x.Id == id);

            if (persona == null)
            {
                return BadRequest("No se encontró el cliente");
            }
            else
            {
                return Ok(persona);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(Persona persona) { 
            if (persona == null)
            {
                return BadRequest("No se enviaron datos de persona.");
            }
            else
            {
                await _context.Personas.AddAsync(persona);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Get", persona.Id, persona);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id) { 
            var persona = await _context.Personas.FirstOrDefaultAsync(x => x.Id == id);

            if (persona == null)
            {
                return BadRequest("No se encontró el cliente");
            }
            else
            {
                _context.Personas.Remove(persona);
                await _context.SaveChangesAsync();
                return Ok();
            }
        }

        [HttpPatch]
        public async Task<IActionResult> Patch(int id, Persona persona) {
            var persona1 = await _context.Personas.FirstOrDefaultAsync(x => x.Id == id);

            if (persona1 == null)
            {
                return BadRequest("No se encontró el cliente");
            }
            else
            {
                persona1.Nombre = persona.Nombre;
                persona1.Apellido = persona.Apellido;
                persona1.DNI    = persona.DNI;
                await _context.SaveChangesAsync();
                return Ok();
            }

        }


        [HttpPut]
        public async Task<IActionResult> Put(int id, Persona persona)
        {
            var persona1 = await _context.Personas.FirstOrDefaultAsync(x => x.Id == id);

            if (persona1 == null)
            {
                return BadRequest("No se encontró el cliente");
            }
            else
            {
                if (persona.Nombre != null) persona1.Nombre = persona.Nombre;
                if (persona.Apellido != null) persona1.Apellido = persona.Apellido;
                if (persona.DNI != null) persona1.DNI = persona.DNI;
                await _context.SaveChangesAsync();
                return Ok();
            }

        }
    }
}

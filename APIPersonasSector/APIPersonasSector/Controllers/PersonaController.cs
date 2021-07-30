using APIPersonasSector.Modelo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIPersonasSector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PersonaController : ControllerBase
    {
        //coment
        private readonly AplicationDbContext _context;
        public PersonaController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<PersonaController>
        [HttpGet]


        public async Task<IActionResult> Get()
        {
            try
            {
                var listPersonas = await _context.Persona.ToListAsync();
                return Ok(listPersonas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //throw;
            }
        }


        // GET api/<PersonaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }



        // POST api/<PersonaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Persona persona)
        {
            try
            {
                _context.Add(persona);
                await _context.SaveChangesAsync();
                return Ok(persona);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //throw;
            }
        }

        // PUT api/<PersonaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Persona persona)
        {
            try
            {
                if (id != persona.Id)
                {
                    return NotFound();
                }

                _context.Update(persona);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Update con exito" });
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //throw;
            }
        }

        // DELETE api/<PersonaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var persona = await _context.Persona.FindAsync(id);


            if (persona == null)
            {
                return NotFound();
            }

            _context.Persona.Remove(persona);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Eliminada con exito" });

        }
    }
}

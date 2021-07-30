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
    public class ZonaController : ControllerBase
    {

        private readonly AplicationDbContext _context;
        public ZonaController(AplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/<ZonaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listZonas = await _context.Zona.ToListAsync();
                return Ok(listZonas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //throw;
            }
        }


        // GET api/<ZonaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ZonaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Zona zona)
        {
            try
            {
                _context.Add(zona);
                await _context.SaveChangesAsync();
                return Ok(zona);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //throw;
            }
        }

        // PUT api/<ZonaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Zona zona)
        {
            try
            {
                if (id != zona.Id)
                {
                    return NotFound();
                }

                _context.Update(zona);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Update con exito" });
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //throw;
            }
        }

        // DELETE api/<ZonaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var zona = await _context.Zona.FindAsync(id);


            if (zona == null)
            {
                return NotFound();
            }

            _context.Zona.Remove(zona);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Eliminada con exito" });

        }
    }
}

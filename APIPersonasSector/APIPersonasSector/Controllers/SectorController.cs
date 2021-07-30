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
    public class SectorController : ControllerBase
    {

        private readonly AplicationDbContext _context;
        public SectorController(AplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/<SectorController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listSectores = await _context.Sector.ToListAsync();
                return Ok(listSectores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //throw;
            }
        }

        // GET api/<SectorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SectorController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Sector sector)
        {
            try
            {
                _context.Add(sector);
                await _context.SaveChangesAsync();
                return Ok(sector);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //throw;
            }
        }

        // PUT api/<SectorController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Sector sector)
        {
            try
            {
                if (id != sector.Id)
                {
                    return NotFound();
                }

                _context.Update(sector);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Update con exito" });
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //throw;
            }
        }


        // DELETE api/<SectorController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sector = await _context.Sector.FindAsync(id);


            if (sector == null)
            {
                return NotFound();
            }

            _context.Sector.Remove(sector);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Eliminada con exito" });

        }
    }
}

using Lab4Json.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4Json.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        FacultateContext db;
        public ValuesController(FacultateContext context)
        {
            db = context;

        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Facultate>>> Get()
        {
            return await db.facultati.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Facultate>> Get(int id)
        {
            Facultate fac = await db.facultati.FirstOrDefaultAsync(x => x.id == id);
            if (fac == null)
                return NotFound();
            return new ObjectResult(fac);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Facultate>> Post(Facultate fac)
        {
            if (fac == null)
            {
                return BadRequest();
            }

            db.facultati.Add(fac);
            await db.SaveChangesAsync();
            return Ok(fac);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Facultate>> Put(Facultate fac)
        {
            if (fac == null)
            {
                return BadRequest();
            }
            if (!db.facultati.Any(x => x.id == fac.id))
            {
                return NotFound();
            }

            db.Update(fac);
            await db.SaveChangesAsync();
            return Ok(fac);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Facultate>> Delete(int id)
        {
            Facultate fac = db.facultati.FirstOrDefault(x => x.id == id);
            if (fac == null)
            {
                return NotFound();
            }
            db.facultati.Remove(fac);
            await db.SaveChangesAsync();
            return Ok(fac);
        }     }
}

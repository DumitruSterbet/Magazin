using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Magazin.Models;
using System.Threading.Tasks;

namespace Magazin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JsonsController : ControllerBase
    {
        ShopContext db;
        public JsonsController(ShopContext context)
        {
            db = context;
          
        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produs>>> Get()
        {
            return await db.Produse.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produs>> Get(int id)
        {
            Produs produs = await db.Produse.FirstOrDefaultAsync(x => x.Id == id);
            if (produs == null)
                return NotFound();
            return new ObjectResult(produs);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Produs>> Post(Produs produs)
        {
            if (produs == null)
            {
                return BadRequest();
            }

            db.Produse.Add(produs);
            await db.SaveChangesAsync();
            return Ok(produs);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Produs>> Put(Produs produs)
        {
            if (produs == null)
            {
                return BadRequest();
            }
            if (!db.Produse.Any(x => x.Id == produs.Id))
            {
                return NotFound();
            }

            db.Update(produs);
            await db.SaveChangesAsync();
            return Ok(produs);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Produs>> Delete(int id)
        {
            Produs produs = db.Produse.FirstOrDefault(x => x.Id == id);
            if (produs == null)
            {
                return NotFound();
            }
            db.Produse.Remove(produs);
            await db.SaveChangesAsync();
            return Ok(produs);
        }
    }
}
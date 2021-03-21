using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Magazin.Models;
using System.Threading.Tasks;

namespace Magazin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JsonsCategoryController : ControllerBase
    {
        ShopContext db;
        public JsonsCategoryController(ShopContext context)
        {
            db = context;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            return await db.Categories.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produs>> Get(int id)
        {
            Category category = await db.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
                return NotFound();
            return new ObjectResult(category);
        }
    }
}

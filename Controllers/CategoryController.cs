using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreWebApi.Models.EF;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApi.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            using (var db = new DatabaseContext())
            { 
                var temp = await db.Categories.ToListAsync();
                return temp;
            }
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> Get(int id)
        {
            using (var db = new DatabaseContext()){
                var temp = await db.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
                return temp;
            }
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Post([FromBody] Category cat)
        {
             using (var db = new DatabaseContext()){
                db.Categories.Add(cat);
                await db.SaveChangesAsync();
                return CreatedAtAction(nameof(Get), new { id = cat.CategoryId }, cat);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Category>> Put(int id, [FromBody] Category cat)
        {
            if (id != cat.CategoryId)
            {
                return BadRequest();
            }
            using (var db = new DatabaseContext())
            {
                db.Entry(cat).State = EntityState.Modified;
                await db.SaveChangesAsync();

                //return NoContent();
                
                return CreatedAtAction(nameof(Get), new { id = cat.CategoryId }, cat);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            using(var db = new DatabaseContext())
            {
                var temp = await db.Categories.FindAsync(id);
                if(temp == null){
                    return NotFound();
                }

                db.Categories.Remove(temp);
                await db.SaveChangesAsync();

                return NoContent();
            }
        }
    }
}
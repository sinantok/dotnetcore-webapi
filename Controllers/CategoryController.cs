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
    [Route("api/[controller]/[action]")]//routePrefix
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            using (var db = new DatabaseContext())
            { 
                var temp = await db.Categories.ToListAsync();
                return temp;
            }
        }
        
        [HttpGet("{id}")]
        //[Route("Get/{id}")] attribute based routing
        public async Task<ActionResult<Category>> GetById(int id)
        {
            using (var db = new DatabaseContext()){
                var temp = await db.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
                return temp;
            }
        }

        [HttpPost]
        public async Task<ActionResult<Category>> InsertPost([FromBody] Category cat)
        {
             using (var db = new DatabaseContext()){
                db.Categories.Add(cat);
                await db.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = cat.CategoryId }, cat);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Category>> UpdatePut(int id, [FromBody] Category cat)
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
                
                return CreatedAtAction(nameof(GetById), new { id = cat.CategoryId }, cat);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
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
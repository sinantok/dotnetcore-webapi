using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreWebApi.Models.EF;

namespace CoreWebApi.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            using (var db = new DatabaseContext())
            {
                var temp = db.Categories.ToList();
                return temp;
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Category> Get(int id)
        {
            using (var db = new DatabaseContext()){
                var temp = db.Categories.FirstOrDefault(x => x.CategoryId == id);
                return temp;
            }
        }

         [HttpPost]
        public void Post([FromBody] Category cat)
        {

        }
    }
}
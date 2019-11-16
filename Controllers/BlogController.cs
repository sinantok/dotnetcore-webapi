using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreWebApi.Models.EF;
using Microsoft.AspNetCore.Authorization;

namespace CoreWebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase  
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<Blog> Get()
        {
            using (var db = new DatabaseContext())
            {
                var temp = db.Blogs.ToList();
                return temp;
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Blog> Get(int id)
        {
            using (var db = new DatabaseContext()){
                var temp = db.Blogs.FirstOrDefault(x => x.BlogId == id);
                return temp;
            }
        }
    }
}
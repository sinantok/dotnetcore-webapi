using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace CoreWebApi.Models.EF{

    public class Category
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int CategoryId { get; set; }
            public string Name { get; set; }

            public virtual List<Blog> Blogs { get; set; }

            public Category()
            {
                Blogs = new List<Blog>();
            }
        }
    }
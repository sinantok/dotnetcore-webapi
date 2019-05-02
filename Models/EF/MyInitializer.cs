using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;

namespace CoreWebApi.Models.EF 
{    
    public static class MyInitializer  
    {
        public static void Seed()
        {
            DatabaseContext context = new DatabaseContext();

            //context.Database.Migrate();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category() { Name = "Cat 1" },
                    new Category() { Name = "Cat 2" }
                    );
                context.SaveChanges();
            }
            
            if (!context.Blogs.Any())
            {
                context.Blogs.AddRange(
                    new Blog() { Title = "Gezi", Description = "afasd", Body = "Blog Body 1", Image = "3.jpeg", Date = DateTime.Now.AddDays(-2), IsApproved = true, CategoryId = 1 },
                    new Blog() { Title = "Gezi2", Description = "afasd", Body = "Blog Body 2", Image = "5.jpeg", Date = DateTime.Now.AddDays(-1), IsApproved = false, CategoryId = 2 }
                    );
                context.SaveChanges();
            }

        }
    }
}
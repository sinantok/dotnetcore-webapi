using Microsoft.EntityFrameworkCore;

namespace CoreWebApi.Models.EF{
    
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(){
        }
        public DbSet<Blog> Blogs {get; set;}
        public DbSet<Category> Categories { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=SINAN-PC;Database=BlogAppDb; Trusted_Connection=true");
        }
        
    }
}
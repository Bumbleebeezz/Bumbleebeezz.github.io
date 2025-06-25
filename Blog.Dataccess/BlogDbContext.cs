using Blog.Dataccess.Entities.Foods;
using Microsoft.EntityFrameworkCore;

namespace Blog.Dataccess
{
    public class BlogDbContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        

        public BlogDbContext() { }
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }
        
    }
}

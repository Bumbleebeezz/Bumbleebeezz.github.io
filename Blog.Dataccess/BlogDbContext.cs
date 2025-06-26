using Blog.Dataccess.Entities.DIY;
using Blog.Dataccess.Entities.Foods;
using Blog.Dataccess.Entities.Photografy;
using Microsoft.EntityFrameworkCore;

namespace Blog.Dataccess
{
    public class BlogDbContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<DoItYourself> DIYs { get; set; }
        public DbSet<Photo> Photos { get; set; }


        public BlogDbContext() { }
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }
        
    }
}

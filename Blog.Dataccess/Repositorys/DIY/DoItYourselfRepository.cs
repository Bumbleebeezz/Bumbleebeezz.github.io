using Blog.Shared.Interfaces.DIY;
using Blog.Dataccess.Entities.DIY;
using Blog.Shared.DTOs.DIY;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;


namespace Blog.Dataccess.Repositorys.DIY
{
    public class DoItYourselfRepository(BlogDbContext context) : IDoItYourselfService<DoItYourself>
    {
        public async Task AddDIYAsync(DoItYourself diy)
        {
            await context.DIYs.AddAsync(diy);
            await context.SaveChangesAsync();
        }

        public async Task DeleteDIYAsync(int id)
        {
            var deleteDIY = await context.DIYs.FindAsync(id);
            if (deleteDIY is null)
            {
                return;
            }
            context.DIYs.Remove(deleteDIY);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DoItYourself?>> GetAllDIYsAsync()
        {
            var allDIYs = await context.DIYs.ToListAsync();
            if (allDIYs is null || !allDIYs.Any())
            {
                return null;
            }
            return allDIYs;
        }

        public async Task<DoItYourself?> GetDIYByIdAsync(int id)
        {
            var diy = await context.DIYs.FindAsync(id);
            if (diy is null)
            {
                return null;
            }
            return diy;
        }

        public async Task<IEnumerable<DoItYourself?>> GetDIYsByCategoryAsync(string category)
        {
            var diyByCategory = await context.DIYs
                .Where(d => d.Category.Equals(category))
                .ToListAsync();
            if (diyByCategory is null || !diyByCategory.Any())
            {
                return null;
            }
            return diyByCategory;
        }

        public async Task UpdateDIYAsync(DoItYourselfDto diy)
        {
            var updateDIY = await context.DIYs.FindAsync(diy.Id);
            if (updateDIY is null)
            {
                return;
            }
            updateDIY.Title = diy.Title;
            updateDIY.Description = diy.Description;
            updateDIY.Category = diy.Category;
            updateDIY.Components = diy.Components;
            updateDIY.Instructions = diy.Instructions;
            context.DIYs.Update(updateDIY);
            await context.SaveChangesAsync();
        }
    }
}

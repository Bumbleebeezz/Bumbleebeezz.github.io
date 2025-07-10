using Blog.Shared.Interfaces.DIY;
using Blog.Dataccess.Entities.DIY;
using Blog.Shared.DTOs.DIY;
using Microsoft.EntityFrameworkCore;


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
                throw new KeyNotFoundException($"DIY with ID {id} not found.");
            }
            context.DIYs.Remove(deleteDIY);
            await context.SaveChangesAsync();
        }

        public async Task<List<DoItYourself?>> GetAllDIYsAsync()
        {
            return await context.DIYs.ToListAsync();
        }

        public async Task<DoItYourself?> GetDIYByIdAsync(int id)
        {
            return await context.DIYs.FindAsync(id)
                ?? throw new KeyNotFoundException($"DIY with ID {id} not found.");
        }

        public async Task<IEnumerable<DoItYourself?>> GetDIYsByCategoryAsync(string category)
        {
            var diyByCategory = await context.DIYs
                .Where(d => d.Category.Equals(category))
                .ToListAsync();
            if (diyByCategory is null || !diyByCategory.Any())
            {
                throw new KeyNotFoundException($"DIYs with category {category} not found.");
            }
            return diyByCategory;
        }

        public async Task UpdateDIYAsync(DoItYourselfDto diy)
        {
            var updateDIY = await context.DIYs.FindAsync(diy.Id);
            if (updateDIY is null)
            {
                throw new KeyNotFoundException($"DIY with ID {diy.Id} not found.");
            }
            updateDIY.Name = diy.Name;
            updateDIY.Description = diy.Description;
            updateDIY.Category = diy.Category;
            updateDIY.Components = diy.Components;
            updateDIY.Instructions = diy.Instructions;
            context.DIYs.Update(updateDIY);
            await context.SaveChangesAsync();
        }
    }
}

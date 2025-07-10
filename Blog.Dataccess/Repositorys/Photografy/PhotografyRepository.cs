using Blog.Dataccess.Entities.Photografy;
using Blog.Shared.DTOs.Photografy;
using Blog.Shared.Interfaces.Photografy;
using Microsoft.EntityFrameworkCore;


namespace Blog.Dataccess.Repositorys.Photografy
{
    public class PhotografyRepository(BlogDbContext context) : IPhotografyService<Photo>
    {
        public async Task AddPhotografyAsync(Photo photografy)
        {
            await context.Photos.AddAsync(photografy);
            await context.SaveChangesAsync();
        }

        public async Task DeletePhotografyAsync(int id)
        {
            var deletePhoto = await context.Photos.FindAsync(id);
            if (deletePhoto is null)
            {
                throw new KeyNotFoundException($"Photo with ID {id} not found.");
            }
            context.Photos.Remove(deletePhoto);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Photo?>> GetAllPhotografiesAsync()
        {
            return await context.Photos.ToListAsync();
        }

        public async Task<IEnumerable<Photo?>> GetPhotografiesByCategoryAsync(string category)
        {
            var photosByCategory = await context.Photos
                .Where(p => p.Category.Equals(category))
                .ToListAsync();
            if (photosByCategory is null || !photosByCategory.Any())
            {
                throw new KeyNotFoundException($"Photos with category {category} not found.");
            }
            return photosByCategory;
        }

        public async Task<Photo?> GetPhotografyByIdAsync(int id)
        {
            return await context.Photos.FindAsync(id)
                ?? throw new KeyNotFoundException($"Photo with ID {id} not found.");
        }

        public async Task UpdatePhotografyAsync(PhotoDto photografy)
        {
            var updatePhoto = await context.Photos.FindAsync(photografy.Id);
            if (updatePhoto is null)
            {
                throw new KeyNotFoundException($"Photo with ID {photografy.Id} not found.");
            }
            updatePhoto.Title = photografy.Title;
            updatePhoto.URL = photografy.URL;
            updatePhoto.Description = photografy.Description;
            updatePhoto.Category = photografy.Category;
            updatePhoto.DateTaken = photografy.DateTaken;
            context.Photos.Update(updatePhoto);
            await context.SaveChangesAsync();
        }
    }
}

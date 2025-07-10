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
                return;
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
                return null;
            }
            return photosByCategory;
        }

        public async Task<Photo?> GetPhotografyByIdAsync(int id)
        {
            var photo = await context.Photos.FindAsync(id);
            if (photo is null)
            {
                return null;
            }
            return photo;
        }

        public async Task UpdatePhotografyAsync(PhotoDto photografy)
        {
            var updatePhoto = await context.Photos.FindAsync(photografy.Id);
            if (updatePhoto is null)
            {
                return;
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

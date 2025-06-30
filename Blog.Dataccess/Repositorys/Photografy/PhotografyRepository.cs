

using Blog.Shared.DTOs.Photografy;
using Blog.Shared.Interfaces.Photografy;
using Microsoft.Graph.Models;

namespace Blog.Dataccess.Repositorys.Photografy
{
    public class PhotografyRepository(BlogDbContext context) : IPhotografyService<Photo>
    {
        public Task AddPhotografyAsync(PhotoDto photografy)
        {
            throw new NotImplementedException();
        }

        public Task DeletePhotografyAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Photo>> GetAllPhotografiesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Photo>> GetPhotografiesByCategoryAsync(string category)
        {
            throw new NotImplementedException();
        }

        public Task<Photo> GetPhotografyByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Photo>> SearchPhotografiesAsync(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePhotografyAsync(PhotoDto photografy)
        {
            throw new NotImplementedException();
        }
    }
}

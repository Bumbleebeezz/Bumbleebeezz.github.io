

using Blog.Shared.DTOs.Photografy;
using Blog.Shared.Interfaces.Photografy;
using Microsoft.Graph.Models;

namespace Blog.Dataccess.Repositorys.Photografy
{
    public class PhotografyRepository(BlogDbContext context) : IPhotografyService
    {
        public Task AddPhotografyAsync(PhotoDto photografy)
        {
            throw new NotImplementedException();
        }

        public Task DeletePhotografyAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PhotoDto>> GetAllPhotografiesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PhotoDto>> GetPhotografiesByCategoryAsync(string category)
        {
            throw new NotImplementedException();
        }

        public Task<PhotoDto> GetPhotografyByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PhotoDto>> SearchPhotografiesAsync(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePhotografyAsync(PhotoDto photografy)
        {
            throw new NotImplementedException();
        }
    }
}

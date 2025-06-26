using Microsoft.Graph;
using Microsoft.Graph.Models;

namespace Blog.Shared.Interfaces.Photografy
{
    public interface IPhotografyService<Photo>
    {
        Task<IEnumerable<Photo>> GetAllPhotografiesAsync();
        Task<Photo> GetPhotografyByIdAsync(int id);
        Task AddPhotografyAsync(Photo photografy);
        Task UpdatePhotografyAsync(Photo photografy);
        Task DeletePhotografyAsync(int id);
        Task<IEnumerable<Photo>> SearchPhotografiesAsync(string searchTerm);
        Task<IEnumerable<Photo>> GetPhotografiesByCategoryAsync(string category);
    }
}

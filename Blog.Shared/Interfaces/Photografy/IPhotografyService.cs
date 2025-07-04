using Blog.Shared.DTOs.Photografy;
using Microsoft.Graph;
using Microsoft.Graph.Models;

namespace Blog.Shared.Interfaces.Photografy
{
    public interface IPhotografyService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllPhotografiesAsync();
        Task<T> GetPhotografyByIdAsync(int id);
        Task<T> AddPhotografyAsync(PhotoDto photografy);
        Task UpdatePhotografyAsync(PhotoDto photografy);
        Task DeletePhotografyAsync(int id);
        Task<IEnumerable<T>> SearchPhotografiesAsync(string searchTerm);
        Task<IEnumerable<T>> GetPhotografiesByCategoryAsync(string category);
    }
}

using Blog.Shared.DTOs.Photografy;
using Microsoft.Graph;
using Microsoft.Graph.Models;

namespace Blog.Shared.Interfaces.Photografy
{
    public interface IPhotografyService
    {
        Task<IEnumerable<PhotoDto>> GetAllPhotografiesAsync();
        Task<PhotoDto> GetPhotografyByIdAsync(int id);
        Task AddPhotografyAsync(PhotoDto photografy);
        Task UpdatePhotografyAsync(PhotoDto photografy);
        Task DeletePhotografyAsync(int id);
        Task<IEnumerable<PhotoDto>> SearchPhotografiesAsync(string searchTerm);
        Task<IEnumerable<PhotoDto>> GetPhotografiesByCategoryAsync(string category);
    }
}

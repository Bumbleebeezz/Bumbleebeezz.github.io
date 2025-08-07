using Blog.Shared.DTOs.Photografy;

namespace Blog.Shared.Interfaces.Photografy
{
    public interface IPhotografyService<T> where T : class
    {
        Task<IEnumerable<T?>> GetAllPhotografiesAsync();
        Task<T?> GetPhotografyByIdAsync(int id);
        Task AddPhotografyAsync(T photografy);
        Task UpdatePhotografyAsync(PhotoDto photografy);
        Task DeletePhotografyAsync(int id);
        Task<IEnumerable<T?>> GetPhotografiesByCategoryAsync(string category);
    }
}

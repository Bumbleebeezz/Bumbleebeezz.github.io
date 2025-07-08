using Blog.Shared.DTOs.DIY;

namespace Blog.Shared.Interfaces.DIY
{
    public interface IDoItYourselfService<T> where T : class
    {
        Task<List<T?>> GetAllDIYsAsync();
        Task<T?> GetDIYByIdAsync(int id);
        Task AddDIYAsync(T diy);
        Task UpdateDIYAsync(DoItYourselfDto diy);
        Task DeleteDIYAsync(int id);
        Task<IEnumerable<T?>> SearchDIYsAsync(string searchDIY);
        Task<IEnumerable<T?>> GetDIYsByCategoryAsync(string category);
    }
}

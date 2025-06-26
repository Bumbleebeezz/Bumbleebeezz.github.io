using Blog.Shared.DTOs.DIY;

namespace Blog.Shared.Interfaces.DIY
{
    public interface IDoItYourselfService
    {
        Task<IEnumerable<DoItYourselfDto>> GetAllDIYsAsync();
        Task<DoItYourselfDto> GetDIYByIdAsync(int id);
        Task AddDIYAsync(DoItYourselfDto diy);
        Task UpdateDIYAsync(DoItYourselfDto diy);
        Task DeleteDIYAsync(int id);
        Task<IEnumerable<DoItYourselfDto>> SearchDIYsAsync(string searchDIY);
        Task<IEnumerable<DoItYourselfDto>> GetDIYsByCategoryAsync(string category);
    }
}

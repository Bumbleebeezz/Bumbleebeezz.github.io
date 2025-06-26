using Blog.Dataccess.Repositorys.DIY;
using Blog.Shared.DTOs.DIY;

namespace Blog.API.Services.DIY
{
    public class DoItYourselfService(DoItYourselfRepository doItYourselfRepository) : IDoItYourselfService
    {
        public async Task AddDIYAsync(DoItYourselfDto diy)
        => await doItYourselfRepository.AddDIYAsync(diy);

        public async Task DeleteDIYAsync(int id)
        => await doItYourselfRepository.DeleteDIYAsync(id);

        public async Task<IEnumerable<DoItYourselfDto>> GetAllDIYsAsync()
        => await doItYourselfRepository.GetAllDIYsAsync();

        public async Task<DoItYourselfDto> GetDIYByIdAsync(int id)
        => await doItYourselfRepository.GetDIYByIdAsync(id);

        public async Task<IEnumerable<DoItYourselfDto>> GetDIYsByCategoryAsync(string category)
        => await doItYourselfRepository.GetDIYsByCategoryAsync(category);

        public async Task<IEnumerable<DoItYourselfDto>> SearchDIYsAsync(string searchDIY)
        => await doItYourselfRepository.SearchDIYsAsync(searchDIY);

        public async Task UpdateDIYAsync(DoItYourselfDto diy)
        => await doItYourselfRepository.UpdateDIYAsync(diy);
    }
}

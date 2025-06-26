using Blog.Dataccess.Repositorys.Photografy;
using Blog.Shared.DTOs.Photografy;

namespace Blog.API.Services.Photografy
{
    public class PhotografyService(PhotografyRepository photografyRepository) : IPhotografyService
    {
        public async Task AddPhotografyAsync(PhotoDto photografy)
        => await photografyRepository.AddPhotografyAsync(photografy);

        public async Task DeletePhotografyAsync(int id)
        => await photografyRepository.DeletePhotografyAsync(id);

        public async Task<IEnumerable<PhotoDto>> GetAllPhotografiesAsync()
        => await photografyRepository.GetAllPhotografiesAsync();

        public async Task<IEnumerable<PhotoDto>> GetPhotografiesByCategoryAsync(string category)
        => await photografyRepository.GetPhotografiesByCategoryAsync(category);

        public async Task<PhotoDto> GetPhotografyByIdAsync(int id)
        => await photografyRepository.GetPhotografyByIdAsync(id);

        public async Task<IEnumerable<PhotoDto>> SearchPhotografiesAsync(string searchTerm)
        => await photografyRepository.SearchPhotografiesAsync(searchTerm);

        public async Task UpdatePhotografyAsync(PhotoDto photografy)
        => await photografyRepository.UpdatePhotografyAsync(photografy);
    }
}

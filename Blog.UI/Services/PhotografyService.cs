using Blog.Shared.DTOs.Photografy;
using Blog.Shared.Interfaces.Photografy;

namespace Blog.UI.Services
{
    public class PhotografyService : IPhotografyService<PhotoDto>
    {
        private readonly HttpClient _httpClient;
        public PhotografyService(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("RestApi");
        }
        public async Task AddPhotografyAsync(PhotoDto photografy)
        {
            await _httpClient.PostAsJsonAsync("api/photografies", photografy);
        }

        public async Task DeletePhotografyAsync(int id)
        {
            var respons = _httpClient.DeleteAsync($"api/photografies/{id}");
            if (!respons.Result.IsSuccessStatusCode)
            {
                throw new Exception("Failed to delete photografy");
            }
            var result = respons.Result.Content.ReadAsStringAsync();
            await _httpClient.DeleteAsync(result.Result);
        }

        public Task<IEnumerable<PhotoDto?>> GetAllPhotografiesAsync()
        {
            var respons = _httpClient.GetAsync("api/photografies");
            if (!respons.Result.IsSuccessStatusCode)
            {
                throw new Exception("Failed to fetch photografies");
            }
            var result = respons.Result.Content.ReadFromJsonAsync<IEnumerable<PhotoDto>>();
            return result ?? Task.FromResult<IEnumerable<PhotoDto?>>(new List<PhotoDto?>());
        }

        public Task<IEnumerable<PhotoDto?>> GetPhotografiesByCategoryAsync(string category)
        {
            var respons = _httpClient.GetAsync($"api/photografies/category/{category}");
            if (!respons.Result.IsSuccessStatusCode)
            {
                throw new Exception("Failed to fetch photografies by category");
            }
            var result = respons.Result.Content.ReadFromJsonAsync<IEnumerable<PhotoDto>>();
            return result ?? Task.FromResult<IEnumerable<PhotoDto?>>(new List<PhotoDto?>());
        }

        public Task<PhotoDto?> GetPhotografyByIdAsync(int id)
        {
            var respons = _httpClient.GetAsync($"api/photografies/{id}");
            if (!respons.Result.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to fetch photografy with ID : {id}");
            }
            var result = respons.Result.Content.ReadFromJsonAsync<PhotoDto>();
            return result ?? Task.FromResult<PhotoDto?>(null);
        }

        public Task<IEnumerable<PhotoDto?>> SearchPhotografiesAsync(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public async Task UpdatePhotografyAsync(PhotoDto photografy)
        {
            await _httpClient.PutAsJsonAsync($"api/photografies/{photografy.Id}", photografy);
        }
    }
}

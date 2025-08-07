using Azure;
using Blog.Shared.DTOs.DIY;
using Blog.Shared.DTOs.Foods;
using Blog.Shared.Interfaces.DIY;

namespace Blog.UI.Services
{
    public class DoItYourselfService : IDoItYourselfService<DoItYourselfDto>
    {
        private readonly HttpClient _httpClient;
        public DoItYourselfService(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("RestApi");
        }

        public async Task AddDIYAsync(DoItYourselfDto diy)
        {
            await _httpClient.PostAsJsonAsync("api/diy", diy);
        }

        public Task DeleteDIYAsync(int id)
        {
            var respons = _httpClient.DeleteAsync($"api/diy/{id}");
            if (!respons.Result.IsSuccessStatusCode)
            {
                throw new Exception("Failed to delete DIY");
            }
            var result = respons.Result.Content.ReadAsStringAsync();
            return _httpClient.DeleteAsync(result.Result);
        }

        public Task<IEnumerable<DoItYourselfDto?>> GetAllDIYsAsync()
        {
            var respons = _httpClient.GetAsync("api/diy");
            if (!respons.Result.IsSuccessStatusCode)
            {
                throw new Exception("Failed to fetch DIYs");
            }
            var result =  respons.Result.Content.ReadFromJsonAsync<IEnumerable<DoItYourselfDto>>();
            return result ?? Task.FromResult<IEnumerable<DoItYourselfDto?>>(new List<DoItYourselfDto?>());
        }

        public Task<DoItYourselfDto?> GetDIYByIdAsync(int id)
        {
            var respons = _httpClient.GetAsync($"api/diy/{id}");
            if (!respons.Result.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to fetch DIY with ID : {id}");
            }
            var result = respons.Result.Content.ReadFromJsonAsync<DoItYourselfDto>();
            return result ?? Task.FromResult<DoItYourselfDto?>(null);
        }

        public Task<IEnumerable<DoItYourselfDto?>> GetDIYsByCategoryAsync(string category)
        {
            var respons = _httpClient.GetAsync($"api/diy/category/{category}");
            if (!respons.Result.IsSuccessStatusCode)
            {
                throw new Exception("Failed to fetch DIYs by category");
            }
            var result = respons.Result.Content.ReadFromJsonAsync<IEnumerable<DoItYourselfDto>>();
            return result ?? Task.FromResult<IEnumerable<DoItYourselfDto?>>(new List<DoItYourselfDto?>());
        }

        public Task<IEnumerable<DoItYourselfDto?>> SearchDIYsAsync(string searchDIY)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateDIYAsync(DoItYourselfDto diy)
        {
            await _httpClient.PutAsJsonAsync($"api/diy/{diy.Id}", diy);
        }
    }
    
    
}

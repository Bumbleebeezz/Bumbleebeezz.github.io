using Azure;
using Blog.Shared.DTOs.Foods;
using Blog.Shared.Interfaces.Foods;

namespace Blog.UI.Services
{
    public class RecipeService : IRecipeService<RecipeDto>
    {
        private readonly HttpClient _httpClient;
        public RecipeService(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("RestApi");
        }

        public async Task AddRecipeAsync(RecipeDto recipe)
        {
            await _httpClient.PostAsJsonAsync("api/recipes", recipe);
        }

        public async Task DeleteRecipeAsync(int id)
        {
            var respons = _httpClient.DeleteAsync($"api/recipes/{id}");
            if (!respons.Result.IsSuccessStatusCode)
            {
                throw new Exception("Failed to delete recipe");
            }
            var result = await respons.Result.Content.ReadAsStringAsync();
            await _httpClient.DeleteAsync(result);
        }

        public Task<IEnumerable<RecipeDto?>> GetAllRecipesAsync()
        {
            var respons = _httpClient.GetAsync("api/recipes");
            if (!respons.Result.IsSuccessStatusCode)
            {
                throw new Exception("Failed to fetch recipes");
            }
            var result = respons.Result.Content.ReadFromJsonAsync<IEnumerable<RecipeDto>>();
            return result ?? Task.FromResult<IEnumerable<RecipeDto?>>(new List<RecipeDto?>());
        }

        public Task<IEnumerable<RecipeDto?>> GetRecipesByCategoryAsync(string category)
        {
            var respons = _httpClient.GetAsync($"api/recipes/category/{category}");
            if (!respons.Result.IsSuccessStatusCode)
            {
                throw new Exception("Failed to fetch recipes by category");
            }
            var result = respons.Result.Content.ReadFromJsonAsync<IEnumerable<RecipeDto>>();
            return result ?? Task.FromResult<IEnumerable<RecipeDto?>>(new List<RecipeDto?>());
        }

        public Task<RecipeDto?> GetRecipeByIdAsync(int id)
        {
            var respons = _httpClient.GetAsync($"api/recipes/{id}");
            if (!respons.Result.IsSuccessStatusCode)
            {
                throw new Exception("Failed to fetch recipe by ID");
            }
            var result = respons.Result.Content.ReadFromJsonAsync<RecipeDto>();
            return result ?? Task.FromResult<RecipeDto?>(null);
        }
        public Task<IEnumerable<RecipeDto?>> SearchRecipesAsync(string searchTerm)
        {
            throw new NotImplementedException();
        }
        public async Task UpdateRecipeAsync(RecipeDto recipe)
        {
            await _httpClient.PutAsJsonAsync($"api/recipes/{recipe.Id}", recipe);
        }
    }  
}

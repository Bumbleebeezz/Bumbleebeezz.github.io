using Blog.Dataccess.Entities.Foods;
using Blog.Shared.DTOs.Foods;
using Blog.Shared.Interfaces.Foods;

namespace Blog.Dataccess.Repositorys.Foods
{
    public class RecipeRepository(BlogDbContext context) : IRecipeService
    {
        public async Task AddRecipeAsync(RecipeDto recipe)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRecipeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RecipeDto>> GetAllRecipesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RecipeDto> GetRecipeByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RecipeDto>> GetRecipesByCategoryAsync(string category)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RecipeDto>> SearchRecipesAsync(string searchRecipe)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRecipeAsync(RecipeDto recipe)
        {
            throw new NotImplementedException();
        }
    }
}

using Blog.Dataccess.Entities.Foods;
using Blog.Shared.Interfaces.Foods;

namespace Blog.Dataccess.Repositorys.Foods
{
    public class RecipeRepository(BlogDbContext context) : IRecipeService<Recipe>
    {
        public Task AddRecipeAsync(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRecipeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Recipe>> GetAllRecipesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Recipe>> GetLatestRecipesAsync(int count)
        {
            throw new NotImplementedException();
        }

        public Task<Recipe> GetRecipeByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Recipe>> GetRecipesByCategoryAsync(string category)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Recipe>> GetTopRatedRecipesAsync(int count)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Recipe>> SearchRecipesAsync(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRecipeAsync(Recipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}

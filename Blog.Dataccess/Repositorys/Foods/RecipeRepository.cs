using Blog.Dataccess.Entities.Foods;
using Blog.Shared.DTOs.Foods;
using Blog.Shared.Interfaces.Foods;

namespace Blog.Dataccess.Repositorys.Foods
{
    public class RecipeRepository(BlogDbContext context) : IRecipeService<Recipe>
    {
        public Task AddRecipeAsync(RecipeDto recipe)
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

        public Task<Recipe> GetRecipeByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Recipe>> GetRecipesByCategoryAsync(string category)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Recipe>> SearchRecipesAsync(string searchRecipe)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRecipeAsync(RecipeDto recipe)
        {
            throw new NotImplementedException();
        }
    }
}

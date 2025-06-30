using Blog.Dataccess.Entities.Foods;
using Blog.Dataccess.Repositorys.Foods;
using Blog.Shared.DTOs.Foods;
using Blog.Shared.Interfaces.Foods;

namespace Blog.API.Services.Foods
{
    public class RecipeService(RecipeRepository recipeRepository) : IRecipeService<Recipe>
    {
        public async Task AddRecipeAsync(RecipeDto recipe)
        => await recipeRepository.AddRecipeAsync(recipe);

        public async Task DeleteRecipeAsync(int id)
        => await recipeRepository.DeleteRecipeAsync(id);

        public async Task<IEnumerable<Recipe>> GetAllRecipesAsync()
        => await recipeRepository.GetAllRecipesAsync();

        public async Task<Recipe> GetRecipeByIdAsync(int id)
        => await recipeRepository.GetRecipeByIdAsync(id);

        public async Task<IEnumerable<Recipe>> GetRecipesByCategoryAsync(string category)
        => await recipeRepository.GetRecipesByCategoryAsync(category);

        public async Task<IEnumerable<Recipe>> SearchRecipesAsync(string searchRecipe)
        => await recipeRepository.SearchRecipesAsync(searchRecipe);

        public async Task UpdateRecipeAsync(RecipeDto recipe)
        => await recipeRepository.UpdateRecipeAsync(recipe);
    }
}

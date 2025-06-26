using Blog.Shared.DTOs.Foods;

namespace Blog.API.Services.Foods
{
    public interface IRecipeService
    {
        /// <summary>
        ///     Get a default list of all recipies.
        /// </summary>
        /// <returns>A list of default recipies</returns>
        Task<IEnumerable<RecipeDto>> GetAllRecipesAsync();
        /// <summary>
        /// Asynchronously retrieves a recipe by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the recipe to retrieve.</param>
        /// <returns>The task result is a <see cref="RecipeDto"/> containing the recipe details.</returns>
        Task<RecipeDto> GetRecipeByIdAsync(int id);
        /// <summary>
        /// Creates a new recipe.
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns>new recipe</returns>
        Task AddRecipeAsync(RecipeDto recipe);
        /// <summary>
        /// Update a recipe.
        /// </summary>
        /// <param name="recipe">Recipe that should be updated</param>
        /// <returns> Updated recipe</returns>
        Task UpdateRecipeAsync(RecipeDto recipe);
        /// <summary>
        ///     Delete a Recipe with a given Id
        /// </summary>
        /// <param name="id">Id of recipe to delete</param>
        /// <returns></returns>
        Task DeleteRecipeAsync(int id);
        /// <summary>
        ///     Get a default recipe by search string.
        /// </summary>
        /// <param searchRecipe="searchRecipe"></param>
        Task<IEnumerable<RecipeDto>> SearchRecipesAsync(string searchRecipe);
        /// <summary>
        ///     Get a default recipe by category.
        /// </summary>
        /// <param category="category">Category of a recipe</param>
        Task<IEnumerable<RecipeDto>> GetRecipesByCategoryAsync(string category);
    }
}

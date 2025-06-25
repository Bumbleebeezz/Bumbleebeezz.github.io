namespace Blog.Shared.Interfaces.Foods
{
    public interface IRecipeService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllRecipesAsync();
        Task<T> GetRecipeByIdAsync(int id);
        Task AddRecipeAsync(T recipe);
        Task UpdateRecipeAsync(T recipe);
        Task DeleteRecipeAsync(int id);
        Task<IEnumerable<T>> SearchRecipesAsync(string searchRecipe);
        Task<IEnumerable<T>> GetRecipesByCategoryAsync(string category);
    }
}

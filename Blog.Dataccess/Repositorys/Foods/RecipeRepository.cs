using Blog.Dataccess.Entities.Foods;
using Blog.Shared.Interfaces.Foods;
using Microsoft.EntityFrameworkCore;


namespace Blog.Dataccess.Repositorys.Foods
{
    public class RecipeRepository(BlogDbContext context) : IRecipeService<Recipe>
    {
        public async Task AddRecipeAsync(Recipe recipe)
        {
            await context.Recipes.AddAsync(recipe);
            await context.SaveChangesAsync();
        }

        public async Task DeleteRecipeAsync(int id)
        {
            var deleteRecipe = await context.Recipes.FindAsync(id);
            if (deleteRecipe is null)
            {
                return;
            }
            context.Recipes.Remove(deleteRecipe);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Recipe?>> GetAllRecipesAsync()
        {
            return await context.Recipes.ToListAsync();
        }

        public async Task<Recipe?> GetRecipeByIdAsync(int id)
        {
            var recipe = await context.Recipes.FindAsync(id);
            if (recipe is null)
            {
                return null;
            }
            return await context.Recipes.FindAsync(id);
        }

        public async Task<IEnumerable<Recipe?>> GetRecipesByCategoryAsync(string category)
        {
            var recipesByCategory = await context.Recipes
                .Where(r => r.Category.Equals(category))
                .ToListAsync();
            if (recipesByCategory is null || !recipesByCategory.Any())
            {
                return null;
            }
            return recipesByCategory;
        }


        public async Task UpdateRecipeAsync(Recipe recipe)
        {
            var updateRecipe = await context.Recipes.FindAsync(recipe.Id);
            if (updateRecipe is null)
            {
                return;
            }
            updateRecipe.Name = recipe.Name;
            updateRecipe.Description = recipe.Description;
            updateRecipe.Category = recipe.Category;
            updateRecipe.Ingredients = recipe.Ingredients;
            updateRecipe.Instructions = recipe.Instructions;
            context.Recipes.Update(updateRecipe);
            await context.SaveChangesAsync();
        }
    }
}

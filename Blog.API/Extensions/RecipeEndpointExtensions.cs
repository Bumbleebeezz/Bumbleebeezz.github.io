using Blog.Dataccess.Entities.Foods;
using Blog.Dataccess.Repositorys.Foods;

namespace Blog.API.Extensions
{
    public static class RecipeEndpointExtensions
    {
        public static IEndpointRouteBuilder MapRecipeEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/recipes", async (RecipeRepository repo) =>
            {
                var recipes = await repo.GetAllRecipesAsync();
                if (recipes is null || !recipes.Any())
                {
                    return Results.NotFound("No recipes found");
                }
                return Results.Ok(recipes);
            });

            app.MapGet("/api/recipes/{id:int}", async (int id, RecipeRepository repo) =>
            {
                var recipe = await repo.GetRecipeByIdAsync(id);
                return recipe is null ? Results.NotFound($"Recipe with ID {id} was not found") : Results.Ok(recipe);
            });

            app.MapGet("/recipes/search/{category}", async (RecipeRepository repo, string category) =>
            {
                var recipes = await repo.GetRecipesByCategoryAsync(category);
                if (recipes is null)
                {
                    return Results.NotFound($"Recipes with category {category} was not found");
                }
                return Results.Ok(recipes);
            });

            app.MapPost("/api/recipes", async (Recipe recipe, RecipeRepository repo) =>
            {
                await repo.AddRecipeAsync(recipe);
                return Results.Ok("Recipe successfully added!");
            });

            app.MapPut("/api/recipes/{id:int}", async (int id, Recipe recipe, RecipeRepository repo) =>
            {
                var existingRecipe = await repo.GetRecipeByIdAsync(id);
                if (existingRecipe is null)
                {
                    return Results.NotFound($"Recipe with id {id} was not found");
                }
                await repo.UpdateRecipeAsync(recipe);
                return Results.Ok($"Recipe with id {id} was updated successfully");
            });

            app.MapDelete("/api/recipes/{id:int}", async (int id, RecipeRepository repo) =>
            {
                var existingRecipe = await repo.GetRecipeByIdAsync(id);
                if (existingRecipe is null)
                {
                    return Results.NotFound($"Recipe with id {id} was not found");
                }
                await repo.DeleteRecipeAsync(id);
                return Results.Ok("Recipe has successfully been removed");
            });

            return app;
        }
    }
}

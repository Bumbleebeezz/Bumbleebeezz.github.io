using Blog.Dataccess;
using Blog.Dataccess.Entities.Foods;
using Blog.Shared.DTOs.Foods;
using Blog.Shared.Interfaces.Foods;
using Blog.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;

namespace Blog.UI.Pages
{
    public class RecipiesModel : PageModel
    {
        private readonly RecipeService _recipeService;
        private readonly ILogger<RecipiesModel> _logger;
        public RecipiesModel(RecipeService recipeService, ILogger<RecipiesModel> logger)
        {
            _recipeService = recipeService;
            _logger = logger;
        }

        [BindProperty]
        public RecipeDto? SelectedRecipe { get; set; } = new RecipeDto();
        public List<RecipeDto> Recipes { get; set; } = new();
        public List<string> Categories { get; set; } = new();

        public async void OnGet()
        {
            try
            {
                Recipes = (await _recipeService.GetAllRecipesAsync()).ToList();
                foreach (var recipe in Recipes)
                {
                    foreach (var category in recipe.Category)
                    {
                        if (Categories.Contains(category))
                        {
                            continue;
                        }
                        else
                        {
                            Categories.Add(category);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to fetch recipes");
                // Handle the error appropriately, e.g., show an error message to the user
            }
        }

        public async Task OnGetRecipe(int id)
        {
            try
            {
                SelectedRecipe = await _recipeService.GetRecipeByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to fetch recipe by ID");
                // Handle the error appropriately, e.g., show an error message to the user
            }
        }
        public async void OnGetCategory(string category)
        {
            try
            {
                Recipes = (await _recipeService.GetRecipesByCategoryAsync(category)).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to fetch recipes by category");
                // Handle the error appropriately, e.g., show an error message to the user
            }
        }
    }
}

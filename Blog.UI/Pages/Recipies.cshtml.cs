using Blog.Dataccess.Entities.Foods;
using Blog.Shared.DTOs.Foods;
using Blog.Shared.Interfaces.Foods;
using Blog.UI.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        public List<RecipeDto> Recipes { get; set; } = new List<RecipeDto>();

        public async void OnGet()
        {
            try
            {
                Recipes = (await _recipeService.GetAllRecipesAsync()).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to fetch recipes");
                // Handle the error appropriately, e.g., show an error message to the user
            }
        }
    }
}

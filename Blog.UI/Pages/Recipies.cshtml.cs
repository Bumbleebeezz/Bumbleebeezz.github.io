using Blog.Dataccess.Entities.Foods;
using Blog.Shared.DTOs.Foods;
using Blog.Shared.Interfaces.Foods;
using Blog.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.UI.Pages
{
    public class RecipiesModel(IRecipeService<Recipe> recipeService) : PageModel
    {
        public void OnGet(){}

        public List<Recipe> DbRecipes { get; set; } = new List<Recipe>();
        public async void OnGetAsync()
        {
            DbRecipes.AddRange(await recipeService.GetAllRecipesAsync());
        }
    }
}

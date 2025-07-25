using Blog.Dataccess.Entities.Foods;
using Blog.Shared.DTOs.DIY;
using Blog.Shared.Interfaces.Foods;
using Blog.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.UI.Pages
{
    public class DoItYourselfModel : PageModel
    {
        private readonly DoItYourselfService _doItYourselfService;
        private readonly ILogger<DoItYourselfModel> _logger;

        public DoItYourselfModel(DoItYourselfService doItYourselfService, ILogger<DoItYourselfModel> logger)
        {
            _doItYourselfService = doItYourselfService;
            _logger = logger;
        }
        [BindProperty]
        public DoItYourselfDto? SelectedDiy { get; set; } = new DoItYourselfDto();
        public List<DoItYourselfDto> DIYs { get; set; } = new();
        public List<string> Categories { get; set; } = new();

        public async void OnGet()
        {
            try
            {
                DIYs = (await _doItYourselfService.GetAllDIYsAsync()).ToList();
                foreach (var diy in DIYs)
                {
                    foreach (var category in diy.Category)
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
                _logger.LogError(ex, "Failed to fetch diys");
                // Handle the error appropriately, e.g., show an error message to the user
            }
        }
        public async Task<JsonResult> OnGetDiy(int id)
        {
            var diy = await _doItYourselfService.GetDIYByIdAsync(id);
            if (diy == null) return new JsonResult(null);

            return new JsonResult(new
            {
                title = diy.Title,
                description = diy.Description,
                components = diy.Components,
                instructions = diy.Instructions
            });
        }
        public async void OnGetCategory(string category)
        {
            try
            {
                DIYs = (await _doItYourselfService.GetDIYsByCategoryAsync(category)).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to fetch recipes by category");
                // Handle the error appropriately, e.g., show an error message to the user
            }
        }
    }
}

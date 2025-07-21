using Blog.Dataccess.Entities.Foods;
using Blog.Shared.DTOs.DIY;
using Blog.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

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
    }
}

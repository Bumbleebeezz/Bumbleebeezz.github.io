using Blog.Dataccess.Entities.Foods;
using Blog.Shared.DTOs.Photografy;
using Blog.Shared.Interfaces.Foods;
using Blog.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.UI.Pages
{
    public class PhotografyModel : PageModel
    {
        private readonly PhotografyService _photografyService;
        private readonly ILogger<PhotografyService> _logger;

        public PhotografyModel(PhotografyService photografyService, ILogger<PhotografyService> logger)
        {
            _photografyService = photografyService;
            _logger = logger;
        }
        [BindProperty]
        public PhotoDto? SelectedPhoto { get; set; } = new PhotoDto();
        public List<PhotoDto> Photos { get; set; } = new();
        public List<string> Categories { get; set; } = new();

        public async void OnGet()
        {
            try
            {
                Photos = (await _photografyService.GetAllPhotografiesAsync()).ToList();
                foreach (var photo in Photos)
                {
                    foreach (var category in photo.Category)
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
                _logger.LogError(ex, "Failed to fetch photos");
                // Handle the error appropriately, e.g., show an error message to the user
            }
        }
        public async Task<JsonResult> OnGetPhoto(int id)
        {
            var photo = await _photografyService.GetPhotografyByIdAsync(id);
            if (photo == null) return new JsonResult(null);

            return new JsonResult(new
            {
                title = photo.Title,
                description = photo.Description,
                DateTime = photo.DateTaken
            });
        }
        public async void OnGetCategory(string category)
        {
            try
            {
                Photos = (await _photografyService.GetPhotografiesByCategoryAsync(category)).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to fetch photos by category");
                // Handle the error appropriately, e.g., show an error message to the user
            }
        }
    }
}

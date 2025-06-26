using Blog.API.Services.Foods;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers.Foods
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class RecipeController(
        IRecipeService recipeService
        ) : ControllerBase
    {
        
    }
}

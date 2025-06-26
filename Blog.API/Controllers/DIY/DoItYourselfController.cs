using Blog.API.Services.DIY;
using Blog.Shared.DTOs.DIY;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers.DIY
{
    [ApiController]
    [Authorize]
    [Route("api/diy/[controller]")]
    public class DoItYourselfController(
        IDoItYourselfService doItYourselfService
        ) : Controller
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoItYourselfDto>>> GetDIYs()
        {
            var diys = await doItYourselfService.GetAllDIYsAsync();
            return Ok(diys);
        }
    }
}

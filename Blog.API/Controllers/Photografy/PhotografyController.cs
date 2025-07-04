
using Blog.Dataccess.Entities.Photografy;
using Blog.Shared.DTOs.Photografy;
using Blog.Shared.Interfaces.Photografy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers.Photografy
{
    [ApiController]
    [Authorize]
    [Route("api/photo/[controller]")]
    public class PhotografyController(
        IPhotografyService<Photo> photografyService
        ) : Controller
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhotoDto>>> GetFeatures(bool includeArchived = false)
        {
            var photos = await photografyService.GetAllPhotografiesAsync();
            return Ok(photos);
        }
    }
}

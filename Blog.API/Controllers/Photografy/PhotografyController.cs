
using Blog.Dataccess.Entities.Photografy;
using Blog.Shared.DTOs.Photografy;
using Blog.Shared.Interfaces.Photografy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers.Photografy
{
    [ApiController]
    [Authorize]
    [Route("api/photografy")]
    public class PhotografyController(
        IPhotografyService<Photo> photografyService
        ) : Controller
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhotoDto>>> GetPhotos(bool includeArchived = false)
        {
            var photos = await photografyService.GetAllPhotografiesAsync();
            return Ok(photos);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PhotoDto?>> GetPhotoById(int id)
        {
            var photo = await photografyService.GetPhotografyByIdAsync(id);
            if (photo == null) return NotFound();
            return Ok(photo);
        }

        [HttpPost]
        public async Task<ActionResult<PhotoDto?>> CreatePhoto(PhotoDto photo)
        {
            // add control if photo already is in db
            var newPhoto = await photografyService.AddPhotografyAsync(photo);
            return Ok($"New photo with title {photo.Title} was created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePhoto(PhotoDto photo)
        {
            if (photo == null) return BadRequest("Photo cannot be null");
            await photografyService.UpdatePhotografyAsync(photo);
            return Ok("Photo has been updated");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePhoto(int id)
        {
            var photo = await photografyService.GetPhotografyByIdAsync(id);
            if (photo == null) return NotFound("Photo not found");
            await photografyService.DeletePhotografyAsync(id);
            return Ok("Photo has been deleted");
        }
    }
}

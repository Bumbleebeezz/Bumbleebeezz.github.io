
using Blog.Dataccess.Entities.Photografy;
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
        
    }
}

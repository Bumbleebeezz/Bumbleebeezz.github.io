using Blog.API.Services.DIY;
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

    }
}

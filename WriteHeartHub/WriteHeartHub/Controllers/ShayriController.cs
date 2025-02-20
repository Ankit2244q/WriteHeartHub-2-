using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WriteHeartHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShayriController : ControllerBase
    {
        private readonly IUserContentService _shayriService;

        public ShayriController(IUserContentService shayriService)
        {
            _shayriService = shayriService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllShayri()
        {
            var shayriList = await _shayriService.GetAllShayriAsync();
            return Ok(shayriList);
        }
    }
}

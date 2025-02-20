using Application.Interfaces;
using Core_Doman.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WriteHeartHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserContentController : ControllerBase
    {
        private readonly IUserContentService _userContent;

        public UserContentController(IUserContentService userContent)
        {
            _userContent = userContent;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllShayri()
        {
            var shayriList = await _userContent.GetAllShayriAsync();
            return Ok(shayriList);
        }

        [HttpGet]
        public async Task<IActionResult> AddUserContent(string post,  int type = 1)
        {
            var shayriList = await _userContent.AddContentAsync(post , type);
            return Ok(shayriList);
        }
    }
}

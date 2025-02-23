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
        //[HttpGet("List")]
        //public async Task<IActionResult> GetAllShayri()
        //{
        //    var shayriList = await _userContent.GetAllShayriAsync();
        //    return Ok(shayriList);
        //}

        [HttpGet]
        public async Task<IActionResult> GetAllShayri()
        {
            try
            {
                var shayriList = await _userContent.GetAllShayriAsync();

                if (shayriList == null || !shayriList.Any())
                {
                    var result = new { status = false, message = "No Shayri found.", data = (object)null };
                    return NotFound(result);
                }

                var successResult = new { status = true, message = "Shayri list retrieved successfully.", data = shayriList };
                return Ok(successResult);
            }
            catch (Exception ex)
            {
                var errorResult = new { status = false, message = ex.Message, data = (object)null };
                return StatusCode(StatusCodes.Status500InternalServerError, errorResult);
            }
        }


        //[HttpPost("Insert")]
        //public async Task<IActionResult> AddUserContent(string post,  int type = 1,int Id,)
        //{
        //    var shayriList = await _userContent.AddContentAsync(post , type,Id);
        //    return Ok(shayriList);
        //}

        [HttpPost("InsertvsUpdate")]
        public async Task<IActionResult> AddUserContent(string post, int type = 1, int? Id = null)
        {
            try
            {
                // If Id is null, pass it as 'default(int)' or use null-coalescing operator (?? 0)
                var shayri = await _userContent.AddContentAsync(post, type, Id ?? 0);

                if (shayri == null)
                {
                    return BadRequest(new  { status = false, message = "Failed to add/update content.", data = new { }  });
                }

                return Ok(new
                {
                    status = true,
                    message = $"Content {(Id == null ? "added" : "updated")} successfully.",
                    action = (Id == null ? "Inserted" : "Updated"),
                    data = new
                    {
                        shayri.Id,
                        shayri.UserId,
                        shayri.Type,
                        shayri.Content,
                        shayri.CreatedAt
                    }
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    status = false,
                    message = "An error occurred while processing your request.",
                    error = ex.Message
                });
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deletedShayri = await _userContent.DeleteUserContentAsync(id);

                if (deletedShayri == null)
                {
                    var result = new { status = false, message = "Shayri not found or already deleted.", data = (object)null };
                    return NotFound(result);
                }

                var successResult = new { status = true, message = "Shayri deleted successfully.", data = deletedShayri };
                return Ok(successResult);
            }
            catch (Exception ex)
            {
                var errorResult = new { status = false, message = "An error occurred while deleting Shayri.", error = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, errorResult);
            }
        }


    }
}

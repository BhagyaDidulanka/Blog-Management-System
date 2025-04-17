using Blog_App.Dto.Request;
using Blog_App.Dto.Response;
using Blog_App.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        
        private readonly IPostServices _postService;

        public PostController(IPostServices postService)
        {
            _postService = postService;
        }


        //POST Rest API.
        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] PostRequestDto postRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            PostResponseDto postResponseDto = await _postService.CreatePost(postRequestDto);
            return Ok(postResponseDto);
        }

        //GET ALL Rest API.
        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            List<PostResponseDto> postResponseDtos = await _postService.GetAllPosts();
            return Ok(postResponseDtos);
        }

        //GET BY ID Rest API.
        [HttpGet("id")]
        public async Task<IActionResult> GetPostById(int id)
        {
            PostResponseDto postResponseDto = await _postService.GetPostById(id);
            return Ok(postResponseDto);
        }

        //UPDATE Rest API.
        [HttpPut]
        public async Task<IActionResult> UpdatePost(int id, [FromBody] PostRequestDto postRequestDto)
        {
            PostResponseDto postResponseDto = await _postService.UpdatePost(id, postRequestDto);
            return Ok(postResponseDto);
        }

        //DELETE Rest API.
        [HttpDelete]
        public async Task<IActionResult> DeletePost(int id)
        {
            bool check = await _postService.DeletePost(id);
            if (check == false)
                return BadRequest("There is no post with the provided Id.");
            else
                return Ok("Post has been deleted.");
        }
    }
    
}

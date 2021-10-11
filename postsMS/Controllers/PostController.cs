using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using postsMS.Dtos.PostDTOs;
using postsMS.Services.PostService;

namespace postsMS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("GetAllPosts")]
        public async Task<IActionResult> GetPosts()
        {
            return Ok(await _postService.GetAllPosts());
        }
        [HttpPost]
        public async Task<IActionResult> AddPost(AddPostDto newPost)
        {
            return Ok(await _postService.AddPost(newPost));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSinglePost(int id)
        {
            return Ok(await _postService.GetPostById(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            List<GetPostDto> response = await _postService.DeletePost(id);
            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

     
    }
}

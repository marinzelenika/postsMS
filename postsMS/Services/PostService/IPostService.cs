using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using postsMS.Dtos.PostDTOs;

namespace postsMS.Services.PostService
{
    public interface IPostService
    {
        Task<List<GetPostDto>> GetAllPosts();
        Task<List<GetPostDto>> AddPost(AddPostDto newPost);
        Task<GetPostDto> GetPostById(int id);
        Task<List<GetPostDto>> DeletePost(int id);
    }
}

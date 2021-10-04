using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using postsMS.Data;
using postsMS.Dtos.PostDTOs;
using postsMS.Models;

namespace postsMS.Services.PostService
{
    public class PostService : IPostService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public PostService(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<GetPostDto>> GetAllPosts()
        {
            List<Posts> dbPosts = await _context.Posts.ToListAsync();
            return dbPosts.Select(p => _mapper.Map<GetPostDto>(p)).ToList();
            
        }

        public async Task<List<GetPostDto>> AddPost(AddPostDto newPost)
        {
           
            Posts post = _mapper.Map<Posts>(newPost);
            post.createdAt = DateTime.Now;
            post.updatedAt = DateTime.Now;
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return _context.Posts.Select(c => _mapper.Map<GetPostDto>(c)).ToList();
        }
    }
}

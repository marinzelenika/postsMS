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
            List<GetPostDto> response = new List<GetPostDto>();
            List<Post> dbPosts = await _context.Posts.ToListAsync();
            response = dbPosts.Select(p => _mapper.Map<GetPostDto>(p)).ToList();
            return response;

        }

        public async Task<List<GetPostDto>> AddPost(AddPostDto newPost)
        {
            List<GetPostDto> response = new List<GetPostDto>();
            Post post = _mapper.Map<Post>(newPost);
            post.createdAt = DateTime.Now;
            post.updatedAt = DateTime.Now;
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            response =  _context.Posts.Select(c => _mapper.Map<GetPostDto>(c)).ToList();
            return response;
        }

        public async Task<GetPostDto> GetPostById(int id)
        {
            List<GetPostDto> response = new List<GetPostDto>();
            Post dbPost = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
            return _mapper.Map<GetPostDto>(dbPost);
            

        }

        public async Task<List<GetPostDto>> DeletePost(int id)
        {
            List<GetPostDto> response = new List<GetPostDto>();
            try
            {
                Post post = await _context.Posts.FirstAsync(p => p.Id == id);
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();

                response =  _context.Posts.Select(p => _mapper.Map<GetPostDto>(p)).ToList();
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public async Task<GetPostDto> UpdatePost(UpdatePostDto updatedPost)
        {


            try
            {
                Post post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == updatedPost.Id);

                post.title = updatedPost.title;
                post.body = updatedPost.body;
                post.createdAt = updatedPost.createdAt;
                post.updatedAt = DateTime.Now;



                _context.Posts.Update(post);
                await _context.SaveChangesAsync();

                return _mapper.Map<GetPostDto>(post);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            

           
        }


    }
}

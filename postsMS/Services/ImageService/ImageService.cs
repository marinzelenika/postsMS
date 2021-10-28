using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using postsMS.Data;
using postsMS.Dtos.ImageDTOs;
using postsMS.Dtos.PostDTOs;
using postsMS.Models;

namespace postsMS.Services.ImageService
{
    public class ImageService : IImageService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public ImageService(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<GetImageDto>> GetAllImagesFromPost(int postId)
        {
            List<GetImageDto> response = new List<GetImageDto>();
            List<Photo> dbImages = await _context.Photos.Where(p => p.Post.Id == postId).ToListAsync();
            response = (dbImages.Select(p => _mapper.Map<GetImageDto>(p))).ToList();
            return response;
        }
    }
}

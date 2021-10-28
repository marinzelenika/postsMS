using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using postsMS.Dtos.ImageDTOs;
using postsMS.Dtos.PostDTOs;
using postsMS.Models;

namespace postsMS
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Post, GetPostDto>();
            CreateMap<AddPostDto, Post>();
            CreateMap<Photo, GetImageDto>();
        }
    }
}

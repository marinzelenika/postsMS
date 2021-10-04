using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using postsMS.Dtos.PostDTOs;
using postsMS.Models;

namespace postsMS
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Posts, GetPostDto>();
            CreateMap<AddPostDto, Posts>();
        }
    }
}

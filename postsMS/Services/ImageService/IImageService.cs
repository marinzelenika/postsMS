using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using postsMS.Dtos.ImageDTOs;

namespace postsMS.Services.ImageService
{
    public interface IImageService
    {
        Task<List<GetImageDto>> GetAllImagesFromPost(int postId);
    }
}

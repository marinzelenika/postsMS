using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using postsMS.Models;

namespace postsMS.Dtos.ImageDTOs
{
    public class GetImageDto
    {
        public int Id { get; set; }
        public string Imagepath { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}

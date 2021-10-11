using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using postsMS.Models;

namespace postsMS.Dtos.PostDTOs
{
    public class GetPostDto
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public int UserID { get; set; }
        public List<Photo> Photos { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace postsMS.Models
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        public string Imagepath { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}

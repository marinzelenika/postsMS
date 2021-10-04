using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace postsMS.Models
{
    public class PhotoFeed
    {
        [Key]
        public int Id { get; set; }
        public string Imagepath { get; set; }
        public ICollection<Posts> posts { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace postsMS.Models
{
    public class Posts
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public int UserID { get; set; }
        public ICollection<PhotoFeed> photos { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperPost.Models
{
    public class PostCategory
    {
        public Post Posts { get; set; }
        public Category Categories { get; set; }
    }

    public class Post
    {
        public int ID { get; set; }
        public string PostTitle { get; set; }
        public string Image { get; set; }
        public DateTime? DateAdded { get; set; }

        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }

        // Hold References to Comment e.g. Navigation Property
        public virtual ICollection<Comment> Comments { get; set; }
        
    }
}
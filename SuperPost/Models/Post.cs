using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperPost.Models
{
    public class Post
    {
        public int ID { get; set; }
        public string PostTitle { get; set; }
        public string Image { get; set; }

        // Hold References to Comment e.g. Navigation Property
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
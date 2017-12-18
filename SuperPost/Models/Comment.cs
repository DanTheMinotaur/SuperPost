using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperPost.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public string CommentText { get; set; }

        // Foreign key to Post
        public int PostID { get; set; }

        public virtual Post Post { get; set; }
    }
}
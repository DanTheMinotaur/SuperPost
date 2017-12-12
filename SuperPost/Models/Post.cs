using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperPost.Models
{
    public class Post
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public DateTime DateAdded { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Category> Categorys { get; set; }
    }

    public class Comment
    {
        public int ID { get; set; }
        public string CommentText { get; set; }
        public DateTime DateAdded { get; set; }
    }

    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SuperPost.Models;

namespace SuperPost.Data_Context
{
    public class SuperPostInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<SuperPostContext>
    {
        protected override void Seed(SuperPostContext context)
        {
            //base.Seed(context);
            var posts = new List<Post>
            {
                new Post{PostTitle="This is a picture", Image="Images/img1.png"}
            };
            posts.ForEach(p => context.Posts.Add(p));
            context.SaveChanges();

            var comments = new List<Comment>
            {
                new Comment{CommentText="First", PostID=1}
            };
            comments.ForEach(c => context.Comments.Add(c));
            context.SaveChanges();
        }
    }
}
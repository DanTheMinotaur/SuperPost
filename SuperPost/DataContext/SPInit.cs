using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SuperPost.Models;


namespace SuperPost.DataContext
{
    public class SPInit : System.Data.Entity. DropCreateDatabaseAlways<SPContext>
    {
        protected override void Seed(SPContext context)
        {
            var posts = new List<Post>
            {
                new Post {PostTitle="This is an image", Image="images/1.jpg", DateAdded=DateTime.Parse("2017-10-14")},
                new Post {PostTitle="Spaaaccceeeee", Image="images/2.jpg", DateAdded=DateTime.Parse("2017-10-14")},
                new Post {PostTitle="Another Space", Image="images/3.jpg", DateAdded=DateTime.Parse("2017-10-14")}
            };

            posts.ForEach(p => context.Posts.Add(p));
            context.SaveChanges();

            var comments = new List<Comment>
            {
                new Comment {CommentText="Hello World", PostID=1, DateAdded=DateTime.Parse("2017-10-15")},
                new Comment {CommentText="Space", PostID=1, DateAdded=DateTime.Parse("2017-10-15")},
                new Comment {CommentText="First", PostID=2, DateAdded=DateTime.Parse("2017-10-15")},
                new Comment {CommentText="Second", PostID=2, DateAdded=DateTime.Parse("2017-10-15")},
                new Comment {CommentText="Nice Image", PostID=3, DateAdded=DateTime.Parse("2017-10-15")},
                new Comment {CommentText="Stupid Image", PostID=3, DateAdded=DateTime.Parse("2017-10-15")},
            };

            comments.ForEach(c => context.Comments.Add(c));
            context.SaveChanges();

        }
    }
}
using SuperPost.Models;
using System;
using System.Collections.Generic;

namespace SuperPost.Data_Context
{
    public class SuperPostInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SuperPostContext>
    {
        protected override void Seed(SuperPostContext context)
        {
            var users = new List<User>
            {
                new User{Name="Daniel", Username="DanTheMin", Email="x15004091@student.ncirl.ie"},
                new User{Name="Sarah", Username="TheHairdryer", Email="x15004033@student.ncirl.ie"},
                new User{Name="Blake", Username="BlakeTheDick", Email="x15004054@student.ncirl.ie"}
            };

            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            var posts = new List<Post>
            {
                new Post{Title="A Sunny Day", Image="Images/img1.png", DateAdded=DateTime.Parse("2017-10-14")},
                new Post{Title="A Rainy Day", Image="Images/img2.png", DateAdded=DateTime.Parse("2017-10-17")},
                new Post{Title="A Bad Day", Image="Images/img3.jpg", DateAdded=DateTime.Parse("2017-11-14")},
                new Post{Title="A Great Day", Image="Images/img4.jpg", DateAdded=DateTime.Parse("2017-11-19")},
            };

            posts.ForEach(p => context.Posts.Add(p));
            context.SaveChanges();

            var comments = new List<Comment>
            {
                new Comment{CommentText="This is a great picture", DateAdded=DateTime.Parse("2017-10-14")},
                new Comment{CommentText="This is a great picture", DateAdded=DateTime.Parse("2017-10-14")},
                new Comment{CommentText="First", DateAdded=DateTime.Parse("2017-10-14")},
                new Comment{CommentText="Second", DateAdded=DateTime.Parse("2017-10-14")},
                new Comment{CommentText="Third", DateAdded=DateTime.Parse("2017-10-14")}
            };

            comments.ForEach(c => context.Comments.Add(c));
            context.SaveChanges();
        }
    }
}
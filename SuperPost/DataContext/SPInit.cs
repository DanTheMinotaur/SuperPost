﻿using System;
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
            var categories = new List<Category>
            {
                new Category {CategoryName="Space"},
                new Category {CategoryName="Animals"}
            };
            categories.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();

            var posts = new List<Post>
            {
                new Post {PostTitle="This is an image", Image="images/1.jpg", DateAdded=DateTime.Parse("2017-10-14"), CategoryID=1},
                new Post {PostTitle="Spaaaccceeeee", Image="images/2.jpg", DateAdded=DateTime.Parse("2017-10-14"), CategoryID=1},
                new Post {PostTitle="Another Space", Image="images/3.jpg", DateAdded=DateTime.Parse("2017-10-14"), CategoryID=1}
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

            var sitecomments = new List<Reviews>
            {
                new Reviews {Name="Dan", Comment="What a great site!", DateTime=DateTime.Parse("2017-12-23")},
                new Reviews {Name="Jane",Comment="Seriously A+ Stuff", DateTime=DateTime.Parse("2017-12-23")},
                new Reviews {Name="Sean",Comment="No flaws with this, if this were a college project I could not fault it", DateTime=DateTime.Parse("2017-12-23")},
            };
            sitecomments.ForEach(sc => context.Reviews.Add(sc));
            context.SaveChanges();


        }
    }
}
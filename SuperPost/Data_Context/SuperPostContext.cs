using System;
using System.Collections.Generic;
using System.Linq;
using SuperPost.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SuperPost.Data_Context
{
    public class SuperPostContext : DbContext
    {
        public SuperPostContext() : base("SuperPostContext")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
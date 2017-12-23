using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SuperPost.DataContext;
using SuperPost.Models;

namespace SuperPost.Controllers
{
    public class Categories1Controller : ApiController
    {
        private SPContext db = new SPContext();

        // GET: api/Categories1
        public IQueryable<Category> GetCategories()
        {
            return db.Categories.ToList().Select(
                c => new Category
                {
                    ID = c.ID,
                    CategoryName = c.CategoryName
                }).AsQueryable();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryExists(int id)
        {
            return db.Categories.Count(e => e.ID == id) > 0;
        }
    }
}
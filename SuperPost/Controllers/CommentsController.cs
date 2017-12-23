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
    public class CommentsController : ApiController
    {
        private SPContext db = new SPContext();

        // GET: api/Comments
        public IQueryable<Comment> GetComments()
        {
            return db.Comments;
        }


        // POST: api/Comments
        [ResponseType(typeof(Comment))]
        public IHttpActionResult PostComment(Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            comment.DateAdded = DateTime.Now;
            db.Comments.Add(comment);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = comment.ID }, comment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CommentExists(int id)
        {
            return db.Comments.Count(e => e.ID == id) > 0;
        }
    }
}
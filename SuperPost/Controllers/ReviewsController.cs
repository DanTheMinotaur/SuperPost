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
    public class ReviewsController : ApiController
    {
        private SPContext db = new SPContext();

        // GET: api/Reviews
        public IQueryable<Reviews> GetReviews()
        {
            return db.Reviews;
        }

        // GET: api/Reviews/5
        [ResponseType(typeof(Reviews))]
        public IHttpActionResult GetReviews(int id)
        {
            Reviews reviews = db.Reviews.Find(id);
            if (reviews == null)
            {
                return NotFound();
            }

            return Ok(reviews);
        }

        // PUT: api/Reviews/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReviews(int id, Reviews reviews)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reviews.ID)
            {
                return BadRequest();
            }

            db.Entry(reviews).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Reviews
        [ResponseType(typeof(Reviews))]
        public IHttpActionResult PostReviews(Reviews reviews)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            reviews.DateTime = DateTime.Now;

            db.Reviews.Add(reviews);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = reviews.ID }, reviews);
        }

        // DELETE: api/Reviews/5
        [ResponseType(typeof(Reviews))]
        public IHttpActionResult DeleteReviews(int id)
        {
            Reviews reviews = db.Reviews.Find(id);
            if (reviews == null)
            {
                return NotFound();
            }

            db.Reviews.Remove(reviews);
            db.SaveChanges();

            return Ok(reviews);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReviewsExists(int id)
        {
            return db.Reviews.Count(e => e.ID == id) > 0;
        }
    }
}
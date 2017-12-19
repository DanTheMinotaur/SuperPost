using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperPost.DataContext;
using SuperPost.Models;


namespace SuperPost.Controllers
{
    public class HomeController : Controller
    {
        private SPContext db = new SPContext();

        public ActionResult Index()
        {
            return View(db.Posts.ToList());
        }
    }
}
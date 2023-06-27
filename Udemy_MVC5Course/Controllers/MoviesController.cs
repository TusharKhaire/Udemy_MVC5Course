using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udemy_MVC5Course.Models;

namespace Udemy_MVC5Course.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shark" };

            return View(movie);
            //return Content("Hello World");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index","Home",new { page=1,sortBy="name"});

        }
        public ActionResult Edit(int id)  //parameterise method
        {
            return Content("Id =" + id);
        }
        public ActionResult Index(int? PageIndex, string SortBy)  // usnig set defaut value
        {
            if (!PageIndex.HasValue)
                PageIndex = 1;
            if (String.IsNullOrEmpty(SortBy))
                SortBy = "Name";

            return Content(String.Format("pageIndex={0}&SortBy={1}", PageIndex, SortBy));
        }
        //Custome Routing method for custome validation with routing
        public ActionResult ByReleaseDate(int year, int month)  
        {
            return Content(year +"/"+ month );
        }
    }
}
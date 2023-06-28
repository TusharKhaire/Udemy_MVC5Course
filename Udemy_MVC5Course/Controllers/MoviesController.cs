using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udemy_MVC5Course.Models;
using Udemy_MVC5Course.ViewModels;

namespace Udemy_MVC5Course.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var newmovie = new Movie() { Name = "Shark" };
            var customers = new List<Customer>
            {
                new Customer{CName="Aditya"},
                new Customer{CName="Vishal"}

            };
            var viewmodel = new RandomMovieViewModel
            {
                movie = newmovie,
                cust=customers
            };

            return View(viewmodel);
            
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

        // Using Attribute routing
        [Route("Movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]     //:regex(\\d{2}):range(1,12)
        public ActionResult ReleasedDate(int year,int month)
        {
            return Content(year + "/" + month);
        }

    }
}
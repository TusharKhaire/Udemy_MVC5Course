using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udemy_MVC5Course.DataConnection;
using Udemy_MVC5Course.Models;
using Udemy_MVC5Course.ViewModels;
using System.Data.Entity;


namespace Udemy_MVC5Course.Controllers
{
    public class MoviesController : Controller
    {
        private DataContext dbconn;
        public MoviesController()
        {
            dbconn = new DataContext();
        }
        protected override void Dispose(bool disposing)
        {
            dbconn.Dispose();
        }
        public ActionResult ShowMovies()
        {
            var data = dbconn.Movies.Include(c=>c.genre).ToList();
            return View(data);
        }
        public ActionResult Details(int id)
        {
            var movie = dbconn.Movies.Include(x => x.genre).SingleOrDefault(x => x.M_id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies
        public ActionResult Random()
        {
            var newmovie = new Movies() { M_Name = "Shark" };
            var customers = new List<Customer>
            {
                new Customer{C_Name="Aditya"},
                new Customer{C_Name="Vishal"}
            };
            var viewmodel = new RandomMovieViewModel
            {
                MoviesName = newmovie,
                Cust = customers
            };

            return View(viewmodel);
            //return Content("Hello World");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index","Home",new { page=1,sortBy="name"});

        }
        [HttpGet]
        [Route("Movies/Index")]
        public ActionResult Index()
        {
            var newmovie = new Movies() { M_Name = "Shark" };
            var customers = new List<Customer>
            {
                new Customer{C_Name="Aditya"},
                new Customer{C_Name="Vishal"}
            };
            var viewmodel = new RandomMovieViewModel
            {
                MoviesName = newmovie,
                Cust = customers
            };
            return View(newmovie);
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
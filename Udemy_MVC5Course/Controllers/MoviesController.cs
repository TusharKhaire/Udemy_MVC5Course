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
        public ActionResult AddMovies()
        {
            var gonre = dbconn.Genres.ToList();
            NewMoviesViewModel newmovie = new NewMoviesViewModel
            {
                Genera = gonre
            };
            return View(newmovie);
        }
        [HttpPost]
        public ActionResult AddMovies(NewMoviesViewModel data)
        {
            // Retrieve the Genre associated with the Movie
            var genre = dbconn.Genres.SingleOrDefault(x => x.Id == data.movie.Genre_Id);

            // Make sure the Genre is found before proceeding
            if (genre != null)
            {
                // Set the Genre navigation property of the Movie
                data.movie.genre = genre;

                // Add the Movie to the Movies DbSet and save changes
                dbconn.Movies.Add(data.movie);
                dbconn.SaveChanges();
            }
            else
            {
                // Handle the case where the specified Genre is not found.
                // You can display an error message or take other actions.
            }

            return RedirectToAction("AddMovies");

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
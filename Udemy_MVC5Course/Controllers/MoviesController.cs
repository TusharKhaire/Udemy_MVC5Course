using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udemy_MVC5Course.DataConnection;
using Udemy_MVC5Course.Models;
using Udemy_MVC5Course.ViewModels;
using System.Data.Entity;
using System.Globalization;

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
            //var data = dbconn.Movies.Include(c=>c.genre).ToList();
            return View();
        }
        public ActionResult Details(int id)
        {
            //var movie = dbconn.Movies.Include(x => x.genre).SingleOrDefault(x => x.M_id == id);
            //if (movie == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }
        public ActionResult AddMovies()
        {
            var gonre = dbconn.Genres.ToList();
            NewMoviesViewModel newmovie = new NewMoviesViewModel
            {
                movie =new Movies(),
                Genera = gonre
            };
            newmovie.movie.ReleaseDate = DateTime.Now;
            newmovie.movie.AddedDate = DateTime.Now;
            return View(newmovie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMovies(NewMoviesViewModel data)
        {
            // Retrieve the Genre associated with the Movie
            var genre = dbconn.Genres.SingleOrDefault(x => x.Id == data.movie.Genre_Id);
            var movies = new Movies();
            // Make sure the Genre is found before proceeding
            DateTime releaseDate;
            DateTime addedDate;

                if (genre != null)
            {
                movies.M_id = data.movie.M_id;
                movies.M_Name = data.movie.M_Name;
                movies.ReleaseDate =Convert.ToDateTime( data.movie.ReleaseDate);
                movies.AddedDate = Convert.ToDateTime(data.movie.AddedDate);
                movies.NumberInStock = data.movie.NumberInStock;
                movies.Genre_Id = data.movie.Genre_Id;
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
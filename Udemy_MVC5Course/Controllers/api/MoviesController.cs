using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Udemy_MVC5Course.DataConnection;
using Udemy_MVC5Course.Dtos;
using Udemy_MVC5Course.Models;

namespace Udemy_MVC5Course.Controllers.api
{
    public class MoviesController : ApiController
    {

        private DataContext dbconn;

        public MoviesController()
        {
            dbconn = new DataContext();
        }

        public IEnumerable<MoviesDto> GetMovies()
        {
            //return dbconn.Movies.ToList().Select(Mapper.Map<Movies, MoviesDto>);
            return dbconn.Movies.ToList().Select(Mapper.Map<Movies, MoviesDto>);
        }

        public IHttpActionResult GetMovies(int id)
        {
            var movies = dbconn.Movies.SingleOrDefault(x => x.M_id == id);
            if (movies == null)
                /// throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            return Ok(Mapper.Map<Movies, MoviesDto>(movies));
        }

        [HttpPost]
        public IHttpActionResult CreateMovies(MoviesDto moviesdto)
        {
            if (!ModelState.IsValid)
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();
            var movies = Mapper.Map<MoviesDto, Movies>(moviesdto);
            dbconn.Movies.Add(movies);
            dbconn.SaveChanges();
            moviesdto.M_id = movies.M_id;
            return Created(new Uri(Request.RequestUri + "/" + movies.M_id), moviesdto);
        }

        [HttpPut]
        public void UpdateMovie(int id, MoviesDto moviedto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = dbconn.Movies.SingleOrDefault(x => x.M_id == id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(moviedto, movieInDb);
            //customerInDb.C_Name = customer.C_Name;
            //customerInDb.Birthdate = customer.Birthdate;
            //customerInDb.IsSubscribeToWatchLetter = customer.IsSubscribeToWatchLetter;
            //customerInDb.MemberShipId = customer.MemberShipId;
            dbconn.SaveChanges();
        }

        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDb = dbconn.Movies.SingleOrDefault(x => x.M_id == id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            dbconn.Movies.Remove(movieInDb);
            dbconn.SaveChanges();
        }

    }
}

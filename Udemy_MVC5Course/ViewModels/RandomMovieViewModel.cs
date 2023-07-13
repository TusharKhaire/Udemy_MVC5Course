using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Udemy_MVC5Course.Models;

namespace Udemy_MVC5Course.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movies MoviesName { get; set; }
        public List<Customer> Cust { get; set; }
    }
}
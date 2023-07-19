using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Udemy_MVC5Course.Models;
namespace Udemy_MVC5Course.ViewModels
{
    public class NewMoviesViewModel
    {
        public IEnumerable<Genres> Genera { get; set; }
        public Movies movie { get; set; }
    }
}
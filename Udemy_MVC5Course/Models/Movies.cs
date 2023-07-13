using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Udemy_MVC5Course.Models
{
    public class Movies
    {
        [Key]
        public int M_id { get; set; }
        public string M_Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime AddedDate { get; set; }
        public byte NumberInStock { get; set; }
        public Genres genre { get; set; }
    }
}
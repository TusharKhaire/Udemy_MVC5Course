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
        [Required]
        public string M_Name { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        public DateTime AddedDate { get; set; }
        [Range(1,20,ErrorMessage ="Please Enter Stock Between only 1 to 20")]
        public byte NumberInStock { get; set; }
        public byte Genre_Id { get; set; }
        //public Genres genre { get; set; }

    }
}
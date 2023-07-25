using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Udemy_MVC5Course.Models;

namespace Udemy_MVC5Course.Dtos
{
    public class CustomerDto
    {
        [Key]
        public int C_id { get; set; }
        [Required]
        [StringLength(255)]
        public string C_Name { get; set; }
        public bool IsSubscribeToWatchLetter { get; set; }
        public byte MemberShipId { get; set; }
        //[Min18YearIfMember]
        public DateTime? Birthdate { get; set; }

    }
}
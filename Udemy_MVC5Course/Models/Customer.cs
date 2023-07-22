using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace Udemy_MVC5Course.Models
{
    public class Customer
    {
        [Key]
        public int C_id { get; set; }
        [Required]
        [StringLength(255)]
        public string C_Name { get; set; }
        public bool IsSubscribeToWatchLetter { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MemberShipId { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Min18YearIfMember]
        public DateTime? Birthdate { get; set; }
    }
}
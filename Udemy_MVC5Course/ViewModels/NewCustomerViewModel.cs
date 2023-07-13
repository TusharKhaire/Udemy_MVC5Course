using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Udemy_MVC5Course.Models;

namespace Udemy_MVC5Course.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer customer { get; set; }
    }
}
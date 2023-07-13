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
    public class CustomerController : Controller
    {
        private DataContext _context;
        public CustomerController()
        {
            _context = new DataContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customer
        public ActionResult Index()
        {
            var customer = _context.Customers.Include(x => x.MembershipType).ToList();
            return View(customer);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(x => x.MembershipType).SingleOrDefault(x => x.C_id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public ActionResult CreateNew()
        {
            var membershiptye = _context.MembershipTypes.ToList();
            var viewmodel = new NewCustomerViewModel
            {
                MembershipTypes = membershiptye
            };
            return View(viewmodel);
        }         
    }
}
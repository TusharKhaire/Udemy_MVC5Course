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
                customer = new Customer(),
                MembershipTypes = membershiptye
            };
            return View(viewmodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNew(NewCustomerViewModel data)
        {
            if (!ModelState.IsValid)
            {
                var viemodel = new NewCustomerViewModel
                {
                    customer = data.customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CreateNew", viemodel);
            }
            var typeid = data.customer.MemberShipId;
            var membershipdata = _context.MembershipTypes.FirstOrDefault(x => x.Id == typeid);
            data.customer.MembershipType = membershipdata;
            if (data.customer.C_id == 0)
            {
                _context.Customers.Add(data.customer);
            }
            else
            {
                var CustomerinDb = _context.Customers.Single(x => x.C_id == data.customer.C_id);
                //Mapper.Map(data.customer,CustomerinDb)
                CustomerinDb.C_Name = data.customer.C_Name;
                CustomerinDb.Birthdate = data.customer.Birthdate;
                CustomerinDb.IsSubscribeToWatchLetter = data.customer.IsSubscribeToWatchLetter;
                CustomerinDb.MembershipType = membershipdata;

            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.C_id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var viewmodelcust = new NewCustomerViewModel
            {
                customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CreateNew", viewmodelcust);
        }
    }
}
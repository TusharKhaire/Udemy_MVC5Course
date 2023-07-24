using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Udemy_MVC5Course.Models;
using Udemy_MVC5Course.DataConnection;
namespace Udemy_MVC5Course.Controllers.api
{
    public class CustomerController : ApiController
    {
        private DataContext dbconn;

        public IEnumerable <Customer> GetCustomers()
        {
            return dbconn.Customers.ToList();
        }

        public Customer GetCustomer(int id)
        {
            var customer = dbconn.Customers.SingleOrDefault(x=>x.C_id==id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customer;
        }

        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            dbconn.Customers.Add(customer);
            dbconn.SaveChanges();

            return customer;
        }

        [HttpPut]
        public void UpdateCustomer(int id,Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = dbconn.Customers.SingleOrDefault(x => x.C_id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            customerInDb.C_Name = customer.C_Name;
            customerInDb.Birthdate = customer.Birthdate;
            customerInDb.IsSubscribeToWatchLetter = customer.IsSubscribeToWatchLetter;
            customerInDb.MemberShipId = customer.MemberShipId;
            dbconn.SaveChanges();
        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var cusomerInDb = dbconn.Customers.SingleOrDefault(x => x.C_id == id);
            if (cusomerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            dbconn.Customers.Remove(cusomerInDb);
            dbconn.SaveChanges();
        }
    }
}

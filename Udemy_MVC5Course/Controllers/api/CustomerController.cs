using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Udemy_MVC5Course.Models;
using Udemy_MVC5Course.DataConnection;
using Udemy_MVC5Course.Dtos;
using AutoMapper;

namespace Udemy_MVC5Course.Controllers.api
{
    public class CustomerController : ApiController
    {
        private DataContext dbconn;

        public CustomerController()
        {
            dbconn = new DataContext(); 
        }

        public IEnumerable <CustomerDto> GetCustomers()
        {
            return dbconn.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>);
        }

        public CustomerDto GetCustomer(int id)
        {
            var customer = dbconn.Customers.SingleOrDefault(x=>x.C_id==id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Customer,CustomerDto>(customer);
        }

        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerdto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customer = Mapper.Map<CustomerDto, Customer>(customerdto);
            dbconn.Customers.Add(customer);
            dbconn.SaveChanges();
            customerdto.C_id = customer.C_id;
            return customerdto;
        }

        [HttpPut]
        public void UpdateCustomer(int id,CustomerDto customerdto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = dbconn.Customers.SingleOrDefault(x => x.C_id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(customerdto, customerInDb);
            //customerInDb.C_Name = customer.C_Name;
            //customerInDb.Birthdate = customer.Birthdate;
            //customerInDb.IsSubscribeToWatchLetter = customer.IsSubscribeToWatchLetter;
            //customerInDb.MemberShipId = customer.MemberShipId;
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

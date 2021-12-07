using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoShop.Models;
using VideoShop.Dtos;
using AutoMapper;
using System.Data.Entity;

namespace VideoShop.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetCustomers(string query=null)
        {
            var allCustomers = _context.Customers.Include(c => c.MembershipType);

            if (allCustomers == null)
                return NotFound();

            if (!String.IsNullOrEmpty(query))
                allCustomers = allCustomers.Where(c => c.Name.Contains(query));

            var customersDto = allCustomers
                .ToList().Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customersDto);
        }

        public IHttpActionResult GetCustomer(int id)
        {
            var getCustomer = _context.Customers.Single(c => c.Id == id);

            if (getCustomer == null)
                return NotFound();
            else
                return Ok(Mapper.Map<Customer, CustomerDto>(getCustomer));
        }


        [HttpPost]
        public IHttpActionResult Create(CustomerDto customerDto)
        {
            _context.Customers.Add(Mapper.Map<CustomerDto, Customer>(customerDto));
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);


            var customerInDb=_context.Customers.Single(C => C.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

                       
            //Mapper.Map<CustomerDto, Customer>(customerDto,customerInDb);


            customerInDb.Name = customerDto.Name;
            customerInDb.Birtdate = customerDto.Birtdate;
            customerInDb.MembershipTypeId = customerDto.MembershipTypeId;
            customerInDb.IsSubscibedToNewsLetter = customerDto.IsSubscibedToNewsLetter;
            _context.SaveChanges();

          var customerUpdated=Mapper.Map<Customer, CustomerDto>(customerInDb);
            
            return Ok(customerUpdated);
        }

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}

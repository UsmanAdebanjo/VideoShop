using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using VideoShop.Models;
using VideoShop.ViewModels;

namespace VideoShop.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
                
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers=_context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult CustomerForm(Customer customer)
        {
            var membershipType = _context.MembershipTypes.ToList();
            var customerViewModel = new CustomerViewModel
            {
                Customer = customer,
                MembershipType = membershipType
            };
            return View(customerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {

            if (!ModelState.IsValid)
            {
                var customerViewModel = new CustomerViewModel
                {
                    Customer = customer,
                    MembershipType = _context.MembershipTypes.ToList()

                };
                return View("CustomerForm", customerViewModel);
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                //TryUpdateModel(customerInDb, new string[] {"Name","MembershipTypeId"});
                customerInDb.Name = customer.Name;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscibedToNewsLetter = customer.IsSubscibedToNewsLetter;
                customerInDb.Birtdate = customer.Birtdate;
            }
            _context.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult Edit(int id)
        {
            var customer=_context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound("Customer not found");
            }
            else
            {
                var customerViewModel = new CustomerViewModel {
                    Customer = customer,
                    MembershipType= _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", customerViewModel);
            }
        }

        [HttpDelete]

        public ActionResult Delete(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                return HttpNotFound("Customer not found");
            }
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
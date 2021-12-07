using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoShop.Models;
using VideoShop.ViewModels;
using VideoShop.Dtos;
namespace VideoShop.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetRentals()
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult GetRental(int id)
        {
            var rental = _context.Rentals.Single(r => r.Id == id);

            return Ok(rental);
        }

        [HttpPost]
        public IHttpActionResult New(NewRentalsViewModelDto newRental)
        {
            var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);
            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();


            if (!ModelState.IsValid)
            {
                return BadRequest("Model not in valid state");
            }

            foreach(var movie in movies)
            {
                if (movie.AvailabileInStock == 0)
                {
                    return BadRequest("Movie not available");
                }
                var rental = new Rental
                {
                    Customer = customer,
                    BorrowedDate = DateTime.Now,
                    Movie=movie
                };
                _context.Rentals.Add(rental);
                movie.AvailabileInStock--;
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}

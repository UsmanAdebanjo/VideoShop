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
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Movies
        public ActionResult Index()
        {
            if (User.IsInRole("CanManageMovies"))
                return View("List");
            return View("ReadOnlyList");
        }

        public ActionResult Detail(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            return View();
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var getMovieInDb = _context.Movies.Single(m=>m.Id==id);
            var genre = _context.Genres.ToList();

            var movieModel = new MovieViewModel
            {
                Genre = genre,
                Movie = getMovieInDb
            };

            return View("MovieForm",movieModel);
        }

        [Authorize(Roles ="CanManageMovies")]
        public ActionResult MovieForm(Movie movie)
        {
            var genre =_context.Genres.ToList();
            var movieViewModel = new MovieViewModel
            {
                Genre = genre,
                Movie = movie
            };
            return View(movieViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save (Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var movieViewModel = new MovieViewModel
                {
                    Genre = _context.Genres.ToList(),
                    Movie = movie
                };

                return View("MovieForm",movieViewModel);


            }
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);
                try
                {
                    TryUpdateModel(movie, new string[] { "Name", "GenreId" });
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
                

            }
            
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        [Authorize(Roles =RoleName.CanManageMovies)]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var getMovieInDb = _context.Movies.Single(m => m.Id == id);

            if (getMovieInDb == null)
            {
                return HttpNotFound("Movie not found");
            }
            else
            {
                _context.Movies.Remove(getMovieInDb);

            }
            
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }


    }
}
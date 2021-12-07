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
    public class MoviesController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetMovies(string query=null)
        {
            var moviesQuery = _context.Movies.Include(m => m.Genre).Where(m=>m.NumberInStock>0);

            if (!String.IsNullOrEmpty(query))
                moviesQuery = moviesQuery.Where(m=>m.Name.Contains(query));

            var moviesDto = moviesQuery.ToList().Select(Mapper.Map<Movie, MovieDto>);

            if (moviesDto == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                return Ok(moviesDto);
            }
        }

        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            else
            {

                return Ok(Mapper.Map<Movie, MovieDto>(movie));
            }
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPost]
        public IHttpActionResult Create(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                var newMovie = Mapper.Map<MovieDto, Movie>(movieDto);
                _context.Movies.Add(newMovie);
                _context.SaveChanges();

                return Ok(Mapper.Map<Movie, MovieDto>(newMovie));

            }
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            var movieInDb=_context.Movies.SingleOrDefault(m => m.Id == id);

            var movieUpdate = Mapper.Map<MovieDto, Movie>(movieDto, movieInDb);

            movieInDb.Name = movieDto.Name;
            movieInDb.DateAdded = movieDto.DateAdded;
            movieInDb.DateReleased = movieDto.DateReleased;
            movieInDb.GenreId = movieDto.GenreId;
            movieInDb.NumberInStock = movieDto.NumberInStock;

            _context.SaveChanges();

            return Ok(HttpStatusCode.Accepted);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.Single(m => m.Id == id);

            if (movieInDb == null)
            {
                return NotFound();
            }
            else
            {
                _context.Movies.Remove(movieInDb);
                _context.SaveChanges();

                return Ok("Deleted");
            }
        }
    }
}

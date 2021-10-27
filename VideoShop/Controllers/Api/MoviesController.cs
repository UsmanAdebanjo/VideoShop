using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoShop.Models;
using VideoShop.Dtos;
using AutoMapper;

namespace VideoShop.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetMovies()
        {
            var movies=_context.Movies.Select(Mapper.Map<Movie, MovieDto>).ToList();

            if (movies == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                return Ok(movies);
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

        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            var movieInDb=_context.Movies.SingleOrDefault(m => m.Id == id);

            var movieUpdate = Mapper.Map<MovieDto, Movie>(movieDto, movieInDb);

            movieInDb.Name = movieDto.Name;
            movieInDb.DateAdded = movieDto.DateAdded;
            movieInDb.DateReleased = movieDto.DateReleased;
            movieInDb.GenreId = movieDto.GenreId;

            _context.SaveChanges();

            return Ok(HttpStatusCode.Accepted);
        }


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

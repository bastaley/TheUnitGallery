using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TheUnitGallery.Models;
using TheUnitGallery.Dtos;
using AutoMapper;

namespace TheUnitGallery.Controllers.API
{
    public class GenresController : ApiController
    {
        private ApplicationDbContext _context;

        public GenresController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/genres
        public IHttpActionResult GetGenres()
        {
            var genreDtos = _context.Genres.ToList().Select(Mapper.Map<Genre, GenreDto>);
            return Ok(genreDtos);
        }

        //GET /api/genres/1
        public IHttpActionResult GetGenre(int id)
        {
            var genre = _context.Genres.SingleOrDefault(c => c.Id == id);

            if (genre == null)
                return NotFound();

            return Ok(Mapper.Map<Genre, GenreDto>(genre));
        }

        // POST /api/genres
        [HttpPost]
        public IHttpActionResult CreateGenre(GenreDto genreDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var genre = Mapper.Map<GenreDto, Genre>(genreDto);

            _context.Genres.Add(genre);
            _context.SaveChanges();

            genreDto.Id = genre.Id;

            return Created(new Uri(Request.RequestUri + "/" + genre.Id), genreDto);
        }


        // PUT /api/genres/1
        public IHttpActionResult UpdateGenre(int id, GenreDto genreDto)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest();

            var genreInDb = _context.Genres.SingleOrDefault(c => c.Id == id);

            if (genreInDb == null)
                return NotFound();

            Mapper.Map(genreDto, genreInDb);

            _context.SaveChanges();

            return Ok();
        }

        // PUT /api/genres/status/1
        public IHttpActionResult ToggleGenreStatus(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var genreInDb = _context.Genres.SingleOrDefault(c => c.Id == id);

            if (genreInDb == null)
                return NotFound();

            if (genreInDb.VisibleFrontEnd)
                genreInDb.VisibleFrontEnd = false;
            else
                genreInDb.VisibleFrontEnd = true;

            _context.SaveChanges();

            return Ok(genreInDb.VisibleFrontEnd);
        }

        // DELETE /api/genres/1
        public IHttpActionResult DeleteGenre(int id)
        {
            var genreInDb = _context.Genres.SingleOrDefault(c => c.Id == id);

            if (genreInDb == null)
                return NotFound();

            _context.Genres.Remove(genreInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}

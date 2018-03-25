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
    public class ArtistsController : ApiController
    {
            private ApplicationDbContext _context;

            public ArtistsController()
            {
                _context = new ApplicationDbContext();
            }

            //GET /api/artists
            public IHttpActionResult GetArtists()
            {
                var artistDtos = _context.Artists.ToList().Select(Mapper.Map<Artist, ArtistDto>);
                return Ok(artistDtos);
            }

            //GET /api/customers/1
            public IHttpActionResult GetArtist(int id)
            {
                var artist = _context.Artists.SingleOrDefault(c => c.Id == id);

                if (artist == null)
                    return NotFound();

                return Ok(Mapper.Map<Artist, ArtistDto>(artist));
            }

            // POST /api/customers
            [HttpPost]
            public IHttpActionResult CreateArtist(ArtistDto artistDto)
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var artist = Mapper.Map<ArtistDto, Artist>(artistDto);

                _context.Artists.Add(artist);
                _context.SaveChanges();

                artistDto.Id = artist.Id;

                return Created(new Uri(Request.RequestUri + "/" + artist.Id), artistDto);
            }


            // PUT /api/customers/1
            public IHttpActionResult UpdateArtist(int id, ArtistDto artistDto)
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var artistInDb = _context.Artists.SingleOrDefault(c => c.Id == id);

                if (artistInDb == null)
                    return NotFound();

                Mapper.Map(artistDto, artistInDb);

                _context.SaveChanges();

                return Ok();
            }

            // DELETE /api/customers/1
            public IHttpActionResult DeleteArtist(int id)
            {
                var artistInDb = _context.Artists.SingleOrDefault(c => c.Id == id);

                if (artistInDb == null)
                    return NotFound();

                _context.Artists.Remove(artistInDb);
                _context.SaveChanges();

                return Ok();
            }
        }
}

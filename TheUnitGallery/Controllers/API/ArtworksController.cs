using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TheUnitGallery.Dtos;
using TheUnitGallery.Models;


namespace TheUnitGallery.Controllers.API
{
    public class ArtworksController : ApiController
    {
        private ApplicationDbContext _context;

        public ArtworksController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/Artworks
        public IHttpActionResult GetArtworks()
        {
            var artworkDtos = _context.Artworks
                .Include(a => a.Artist)
                .Include(a => a.Genre)
                .Include(a => a.Medium)
                .ToList()
                .Select(Mapper.Map<Artwork, ArtworkDto>);

            return Ok(artworkDtos);
        }

        //GET /api/Artworks/1
        public IHttpActionResult GetArtworks(int id)
        {
            var artwork = _context.Artworks.SingleOrDefault(c => c.Id == id);

            if (artwork == null)
                return NotFound();

            return Ok(Mapper.Map<Artwork, ArtworkDto>(artwork));
        }

        // POST /api/Artworks
        [HttpPost]
        public IHttpActionResult CreateArtwork(ArtworkDto artworkDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var artwork = Mapper.Map<ArtworkDto, Artwork>(artworkDto);

            _context.Artworks.Add(artwork);
            _context.SaveChanges();

            artworkDto.Id = artwork.Id;

            return Created(new Uri(Request.RequestUri + "/" + artwork.Id), artworkDto);
        }


        // PUT /api/Artworks/1
        public IHttpActionResult UpdateArtwork(int id, ArtworkDto artworkDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var artworkInDb = _context.Artworks.SingleOrDefault(c => c.Id == id);

            if (artworkInDb == null)
                return NotFound();

            Mapper.Map(artworkDto, artworkInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/Artworks/1
        public IHttpActionResult DeleteArtwork(int id)
        {
            var artworkInDb = _context.Artworks.SingleOrDefault(c => c.Id == id);

            if (artworkInDb == null)
                return NotFound();

            _context.Artworks.Remove(artworkInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}

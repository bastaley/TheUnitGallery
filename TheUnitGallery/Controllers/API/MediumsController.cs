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
    public class MediumsController : ApiController
    {
        private ApplicationDbContext _context;

        public MediumsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/mediums
        public IHttpActionResult GetMediums()
        {
            var mediumDtos = _context.Mediums.ToList().Select(Mapper.Map<Medium, MediumDto>);
            return Ok(mediumDtos);
        }

        //GET /api/mediums/1
        public IHttpActionResult GetMedium(int id)
        {
            var medium = _context.Mediums.SingleOrDefault(c => c.Id == id);

            if (medium == null)
                return NotFound();

            return Ok(Mapper.Map<Medium, MediumDto>(medium));
        }

        // POST /api/mediums
        [HttpPost]
        public IHttpActionResult CreateMedium(MediumDto mediumDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var medium = Mapper.Map<MediumDto, Medium>(mediumDto);

            _context.Mediums.Add(medium);
            _context.SaveChanges();

            mediumDto.Id = medium.Id;

            return Created(new Uri(Request.RequestUri + "/" + medium.Id), mediumDto);
        }


        // PUT /api/genres/status/1
        public IHttpActionResult ToggleMediumStatus(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var mediumInDb = _context.Mediums.SingleOrDefault(c => c.Id == id);

            if (mediumInDb == null)
                return NotFound();

            if (mediumInDb.VisibleFrontEnd)
                mediumInDb.VisibleFrontEnd = false;
            else
                mediumInDb.VisibleFrontEnd = true;

            _context.SaveChanges();

            return Ok(mediumInDb.VisibleFrontEnd);
        }

        // PUT /api/mediums/1
        public IHttpActionResult UpdateMedium(int id, MediumDto mediumDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var mediumInDb = _context.Mediums.SingleOrDefault(c => c.Id == id);

            if (mediumInDb == null)
                return NotFound();

            Mapper.Map(mediumDto, mediumInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/mediums/1
        public IHttpActionResult DeleteMedium(int id)
        {
            var mediumInDb = _context.Mediums.SingleOrDefault(c => c.Id == id);

            if (mediumInDb == null)
                return NotFound();

            _context.Mediums.Remove(mediumInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}

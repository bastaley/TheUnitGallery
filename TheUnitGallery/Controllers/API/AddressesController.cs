using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TheUnitGallery.Dtos;
using TheUnitGallery.Models;

namespace TheUnitGallery.Controllers.API
{
    public class AddressesController : ApiController
    {
        private ApplicationDbContext _context;

        public AddressesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/Address
        public IHttpActionResult GetAddress()
        {
            var addressDtos = _context.Address.ToList().Select(Mapper.Map<Address, AddressDto>);
            return Ok(addressDtos);
        }

        //GET /api/Address/1
        public IHttpActionResult GetAddress(int id)
        {
            var address = _context.Address.SingleOrDefault(c => c.Id == id);

            if (address == null)
                return NotFound();

            return Ok(Mapper.Map<Address, AddressDto>(address));
        }

        // POST /api/Address
        [HttpPost]
        public IHttpActionResult CreateAddress(AddressDto addressDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var address = Mapper.Map<AddressDto, Address>(addressDto);

            _context.Address.Add(address);
            _context.SaveChanges();

            addressDto.Id = address.Id;

            return Created(new Uri(Request.RequestUri + "/" + address.Id), addressDto);
        }


        // PUT /api/Address/1
        public IHttpActionResult UpdateAddress(int id, AddressDto addressDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var addressInDb = _context.Address.SingleOrDefault(c => c.Id == id);

            if (addressInDb == null)
                return NotFound();

            Mapper.Map(addressDto, addressInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/Address/1
        public IHttpActionResult DeleteAddress(int id)
        {
            var addressInDb = _context.Address.SingleOrDefault(c => c.Id == id);

            if (addressInDb == null)
                return NotFound();

            _context.Address.Remove(addressInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}

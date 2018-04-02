using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TheUnitGallery.Models;
using TheUnitGallery.Dtos;
using AutoMapper;
using System.Data.Entity;

namespace TheUnitGallery.Controllers.API
{
    public class InteractionsController : ApiController
    {
        private ApplicationDbContext _context;

        public InteractionsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/interactions/
        public IHttpActionResult GetInteractions()
        {
            var interactionDtos = _context.Interactions.Include(i => i.Staff).ToList().Select(Mapper.Map<Interaction, InteractionDto>);
            return Ok(interactionDtos);
        }

        //GET /api/interactions/1
        public IHttpActionResult GetInteractions(int customerId)
        {
            var interactionDtos = _context.Interactions.Include(i => i.Staff).Where(i => i.CustomerId == customerId).ToList().Select(Mapper.Map<Interaction, InteractionDto>);
            return Ok(interactionDtos);
        }

        // POST /api/interactions/21
        [HttpPost]
        public IHttpActionResult LogInteraction(InteractionDto interactionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var interaction = Mapper.Map<InteractionDto, Interaction>(interactionDto);

            _context.Interactions.Add(interaction);
            _context.SaveChanges();

            interactionDto.Id = interaction.Id;

            return Created(new Uri(Request.RequestUri + "/" + interaction.Id), interactionDto);
        }
    }
}

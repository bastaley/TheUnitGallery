using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TheUnitGallery.Models;
using TheUnitGallery.Dtos;

namespace TheUnitGallery.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDto>();
                cfg.CreateMap<CustomerDto, Customer>();
                cfg.CreateMap<Artist, ArtistDto>();
                cfg.CreateMap<ArtistDto, Artist>();
                cfg.CreateMap<Artwork, ArtworkDto>();
                cfg.CreateMap<ArtworkDto, Artwork>();
                cfg.CreateMap<Genre, GenreDto>();
                cfg.CreateMap<GenreDto, Genre>();
                cfg.CreateMap<Medium, MediumDto>();
                cfg.CreateMap<MediumDto, Medium>();
                cfg.CreateMap<Address, AddressDto>();
                cfg.CreateMap<AddressDto, Address>();
                cfg.CreateMap<Interaction, InteractionDto>();
                cfg.CreateMap<InteractionDto, Interaction>();
                cfg.CreateMap<Order, OrderDto>();
                cfg.CreateMap<OrderDto, Order>();
            });

        }
    }
}
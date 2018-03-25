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
                cfg.CreateMap<Genre, GenreDto>();
                cfg.CreateMap<GenreDto, Genre>();
            });

        }
    }
}
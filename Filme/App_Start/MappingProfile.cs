using System;
using AutoMapper;
using Filme.Core.Dtos;
using Filme.Core.Models;
using Filme.Core.ViewModels;

namespace Filme
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        { //automapper
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MoviesDto>();

            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<MoviesDto, Movie>();

            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();



            //// Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>()
                            .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<MoviesDto, Movie>()
                            .ForMember(c => c.Id, opt => opt.Ignore());


            //mappings in the controller
            Mapper.CreateMap<MembershipTypesViewModel, Customer>()
                .ForMember(c => c.Name, opt => opt.MapFrom(mt => mt.Customers.Name))
                .ForMember(c => c.Birthdate, opt => opt.MapFrom(mt => mt.Customers.Birthdate))
                .ForMember(c => c.MembershipTypeId, opt => opt.MapFrom(mt => mt.Customers.MembershipTypeId))
                .ForMember(c => c.Address, opt => opt.MapFrom(mt => mt.Customers.Address))
                .ForMember(c => c.IsSubscribedToNewsLetter,
                    opt => opt.MapFrom(mt => mt.Customers.IsSubscribedToNewsLetter));

            Mapper.CreateMap<GenreMovieViewModel, Movie>()
                .ForMember(m => m.Name, opt => opt.MapFrom(gm => gm.Movies.Name))
                .ForMember(m => m.Genre, opt => opt.MapFrom(gm => gm.Movies.Genre))
                .ForMember(m => m.DateAdded, opt => opt.MapFrom(gm => DateTime.Now))
                .ForMember(m => m.ReleaseDate, opt => opt.MapFrom(gm => gm.Movies.ReleaseDate))
                .ForMember(m => m.NumberInStock, opt => opt.MapFrom(gm => gm.Movies.NumberInStock))
                .ForMember(m => m.AvailableInStock, opt => opt.MapFrom(gm => gm.Movies.NumberInStock))
                .ForMember(m => m.Description, opt => opt.MapFrom(gm => gm.Movies.Description));

        }
    }
}
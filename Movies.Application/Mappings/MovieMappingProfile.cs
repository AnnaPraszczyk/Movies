using AutoMapper;
using Movies.Application.Movie;
using Movies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Mappings
{
    public class MovieMappingProfile : Profile
    {
        public MovieMappingProfile()
        {
            CreateMap<MovieDto, Domain.Entities.Movie>()
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => new MovieDetails()
                {
                    Genre = src.Genre,
                    Year = ParseYear(src.Year),
                    Director = src.Director
                }));

            CreateMap<Domain.Entities.Movie, MovieDto>()
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Details.Year.HasValue? 
                src.Details.Year.Value.ToString("yyyy") : null))
                .ForMember(dest => dest.EncodedName, opt => opt.MapFrom(src => src.EncodedTitle))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Details.Genre))
                .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Details.Director));
        }

        private static DateTime? ParseYear(string? year)
        {
            if (string.IsNullOrEmpty(year))
                return null;

            if (DateTime.TryParseExact(year, "yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime parsedYear))
                return new DateTime(parsedYear.Year, 1, 1);

            throw new FormatException("Invalid Year format");
        }
    }

}




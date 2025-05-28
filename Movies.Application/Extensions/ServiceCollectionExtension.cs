using Microsoft.Extensions.DependencyInjection;
using Movies.Domain.Interfaces;
using Movies.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movies.Application.Mappings;
using FluentValidation.AspNetCore;
using FluentValidation;
using Movies.Application.Movie;

namespace Movies.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();
            services.AddAutoMapper(typeof(MovieMappingProfile));
            services.AddValidatorsFromAssemblyContaining<MovieDtoValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Movies.Domain.Interfaces;
using Movies.Infrastructure.Persistance;
using Movies.Infrastructure.Repositories;
using Movies.Infrastructure.Seeders;

namespace Movies.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<MoviesDbContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("Movies")));
            services.AddScoped<MovieSeeder>();
            services.AddScoped<IMovieRepository, MovieRepository>();
        }
    }
}

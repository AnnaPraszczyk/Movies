using Microsoft.EntityFrameworkCore;
using Movies.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Seeders
{
    public class MovieSeeder
    {
        private readonly MoviesDbContext _dbContext;
        public MovieSeeder(MoviesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())  //Sprawdzenie połączenia z bazą danych
            {
                if (!_dbContext.Movies.Any())  //Sprawdzamy, czy tabela jest pusta
                {
                    var movie = new Domain.Entities.Movie()
                    {
                        Title = "Inception",
                        Description = "A thief who steals corporate secrets through " +
                        "the use of dream-sharing technology is given the inverse task " +
                        "of planting an idea into the mind of a CEO.",
                        CreatedAt = DateTime.UtcNow,
                        Details = new Domain.Entities.MovieDetails
                        {
                            Genre = "Action, Sci-Fi",
                            Year = new DateTime(2010, 7, 16),
                            Director = "Christopher Nolan",
                        }
                    };
                    movie.EncodeTitle(); // Encode the title before saving
                    _dbContext.Movies.Add(movie);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}


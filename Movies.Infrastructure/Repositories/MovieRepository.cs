using Microsoft.EntityFrameworkCore;
using Movies.Domain.Interfaces;
using Movies.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Repositories
{
    internal class MovieRepository : IMovieRepository
    {
        
        private readonly MoviesDbContext _dbContext;
        public MovieRepository(MoviesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(Domain.Entities.Movie movie)
        {
            _dbContext.Add(movie);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Domain.Entities.Movie>> GetAll()
            => await _dbContext.Movies.ToListAsync();
    }
}

using Movies.Application.Movie;
using Movies.Domain.Entities;

namespace Movies.Application.Services
{
    public interface IMovieService
    {
        Task Create(MovieDto movie);
        Task<IEnumerable<MovieDto>> GetAll();
    }
}
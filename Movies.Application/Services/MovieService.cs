using AutoMapper;
using Movies.Application.Movie;
using Movies.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }
        public async Task Create(MovieDto movieDto)
        {
            var movie = _mapper.Map<Domain.Entities.Movie>(movieDto);
            movie.EncodeTitle();
            await _movieRepository.Create(movie);
        }

        public async Task<IEnumerable<MovieDto>> GetAll()
        {
            var movies = await _movieRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<MovieDto>>(movies);
            return dtos;
        }
    }
}

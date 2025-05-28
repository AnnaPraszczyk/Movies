using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Interfaces
{
    public interface IMovieRepository
    {
        Task Create(Domain.Entities.Movie movie);
        Task<IEnumerable<Domain.Entities.Movie>> GetAll();

    }
}

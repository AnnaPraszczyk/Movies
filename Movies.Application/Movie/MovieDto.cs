using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Movie
{
    public class MovieDto
    {
    
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public string? Genre { get; set; }
        public string? Year { get; set; }
        public string? Director { get; set; }

        public string? EncodedName { get; set; }
    }
}

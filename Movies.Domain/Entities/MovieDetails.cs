using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Entities
{
    public class MovieDetails
    {
        public string? Genre { get; set; }
        public DateTime? Year { get; set; }  
        public string? Director { get; set; }  
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public MovieDetails Details { get; set; } = default!;

        public string EncodedTitle { get; private set; } = default!;
        public void EncodeTitle() => EncodedTitle = Title.ToLower().Replace(" ", "-");
    }
    
}

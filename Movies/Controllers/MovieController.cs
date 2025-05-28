using Microsoft.AspNetCore.Mvc;
using Movies.Application.Movie;
using Movies.Application.Services;

namespace Movies.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public async Task<IActionResult> Index()
        {
            var movies = await _movieService.GetAll();
            return View(movies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] //Przyjmuje dane z formularza
        public async Task<ActionResult> Create(MovieDto movie)
        {
            if (!ModelState.IsValid)
            {
                return View(movie);
            }
            await _movieService.Create(movie);
            return RedirectToAction(nameof(Index));  
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Movies.Models;
using System.Diagnostics;

namespace Movies.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			var model = new List<Person>()
			{
				new Person()
				{
					FirstName = "Jan",
					LastName = "Nowak"
				},
				new Person()
				{
					FirstName = "Adam",
					LastName = "Kowalski"
				},
			};
			return View(model);
		}
        public IActionResult About()
        {
            var model = new About()
            {
                Title ="Movies apllication",
				Description = "Some description",
				Tags =new List<string>() { "movies", "app", "free" }
            };
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}

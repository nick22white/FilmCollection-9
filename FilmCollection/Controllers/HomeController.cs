using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FilmCollection.Models;

namespace FilmCollection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private MovieDbContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieDbContext con)
        {
            _logger = logger;
            context = con;
        }

        //Calls Index.cshtml
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //Calls Podcasts.cshtml, send to page
        public IActionResult Podcasts()
        {
            return View();
        }

        //If get method, calls this to open the NewMovies
        [HttpGet]
        public IActionResult NewMovies()
        {
            return View();
        }

        //When the form is called with method post, comes here and opens AllMovies
        //Checks to see if the  movie is Independence day and won't post that
        [HttpPost]
        public IActionResult NewMovies(NewMovie newMovie)
        {
            if (ModelState.IsValid)
            {
                TempStorage.AddApplication(newMovie);
                context.NewMovies.Add(newMovie);
                context.SaveChanges();
                return View("NewMovies", newMovie);

            }
            else
            {
                return View();
            }
            
        }

        //Opens all movies page and checks to see if it is Independence Day and won't add that
        public IActionResult AllMovies()
        {
            return View(context.NewMovies);
        }

        //Delete
        [HttpPost]
        public IActionResult Delete(int deleteId)
        {
            context.Remove(context.NewMovies.FirstOrDefault(s => s.MovieId == deleteId));
            context.SaveChanges();
            return View("AllMovies", context.NewMovies);
        }

        //Gets the movie id and sets it to the viewbag
        [HttpPost]
        public IActionResult EditMovie(int editId)
        {
            NewMovie editMovie = context.NewMovies.FirstOrDefault(s => s.MovieId == editId);
            ViewBag.editedMovie = editMovie;
            return View("MovieEdit");
        }

        //SAves values into the DbContext
        [HttpPost]
        public IActionResult Edit(NewMovie newEdits)
        {
            if (ModelState.IsValid)
            {
                var editMovie = context.NewMovies.FirstOrDefault(s => s.MovieId == newEdits.MovieId);
                editMovie.Category = newEdits.Category;
                editMovie.Title = newEdits.Title;
                editMovie.Year = newEdits.Year;
                editMovie.Director = newEdits.Director;
                editMovie.Rating = newEdits.Rating;
                editMovie.Edited = newEdits.Edited;
                editMovie.LentTo = newEdits.LentTo;
                editMovie.Notes = newEdits.Notes;
                context.SaveChanges();
                return View("AllMovies", context.NewMovies);
            }
            else
            {
                ViewBag.editedMovie = newEdits; 
                return View("MovieEdit");
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

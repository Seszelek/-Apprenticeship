using Microsoft.AspNetCore.Mvc;
using MoviesExample.Models;
using MoviesExample.Repo;

namespace MoviesExample.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MoviesRepo MR;

        public MoviesController(MoviesRepo MR)
        {
            this.MR = MR;
        }

        //GET
        [HttpGet]
        public IEnumerable<Movie> GetMovies()
        {
            var movies = MR.GetMovies();
            return movies;
        }

        //POST
        [HttpPost]
        public IActionResult AddNewMovie(string title, string filmgenre, string director, int yearofpremiere)
        {
            MR.AddNewMovie(new Movie(title, filmgenre, director, yearofpremiere));
            return Ok("Movie added to the base.");
        }

        //GET - last added
        [HttpGet("lastAdded")]
        public IActionResult ShowLastAddedMovie()
        {
            var lastAdded = MR.ShowLastAddedMovie();
            return Ok(lastAdded);
        }

        //GET - movie by year 
        [HttpGet("year")]
        public IActionResult GetMovieYear(int yearOfPremiere)
        {
            var movieYear = MR.GetMovieYear(yearOfPremiere);
            return Ok (movieYear);
        }

        //GET - movie by genre
        [HttpGet("genre")]
        public IActionResult GetMovieGenre(string filmGenre)
        {
            var movieGenre = MR.GetMovieGenre(filmGenre);
            return Ok (movieGenre);
        }
    }
}

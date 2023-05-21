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


/*
 * 
Movie catalog:

1.Tech stack: dotnet core
2.Domain:
    a.Movie Catalog REST API, that contains the following methods:
        i.      POST: allows to add a movie to the catalog,       <<<--- DONE
        ii.     GET: allows retrieving the last added movie,      <<<--- DONE
        iii.    GET/[year]: retrieves movies from a given year,   <<<--- DONE
        iv.     GET/[genre]: retrieves movies from a given genre. <<<--- DONE

    b.Data can be stored in memory or text file (no DB is required – unless you want to, then use any DB that you can stash in docker).

3.Additional requirements:
    a.Logging HTTP requests to the console.
    b.“Write your code as well as you can.”
    c.Code must compile without warnings (tip: we’ll use the ‘dotnet build’ command)
    d.Code must run (tip: well use ‘dotnet run’ command)

4.Optional: write with unit tests if you can.

*/
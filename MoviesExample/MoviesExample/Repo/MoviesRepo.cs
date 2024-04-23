using MoviesExample.Models;

namespace MoviesExample.Repo
{
    public class MoviesRepo
    {
        public List<Movie> movies = new()
        {
            new Movie ("The Green Mile", "Drama", "Frank Darabont",1999),
            new Movie ("The Silence of the Lambs", "Thriller", "Jonathan Demme", 1991),
            new Movie ("Avatar", "Science Fiction", "James Cameron", 2009)
        };
        
        public bool IsMovieInDatabase(string title)
        {
            foreach (var movie in movies)
            {
                if (movie.Title.Equals(title))
                {
                    return true;
                }
            }
            return false;
        }
    
        
        public void AddNewMovie(Movie movie)
        {
            movies.Add(movie);
        }

        public IEnumerable<Movie> GetMovies()
        { 
            return movies;
        }

        public Movie? ShowLastAddedMovie()
        {
            return movies.LastOrDefault(); 
        }

        public IEnumerable <Movie> GetMovieYear(int yearOfPremiere)
        {
            return movies.Where(movies => movies.YearOfPremiere == yearOfPremiere);
        }

        public IEnumerable<Movie> GetMovieGenre(string filmGenre)
        {
            return movies.Where(movies => movies.FilmGenre.Equals(filmGenre, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}


/* example to add
 "title": "The Godfather",
 "filmGenre": "Drama",
 "director": "Francis Ford Coppola",
 "yearOfPremiere": 1972 
*/
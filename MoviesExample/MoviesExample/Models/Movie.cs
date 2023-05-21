using System.ComponentModel.DataAnnotations;

namespace MoviesExample.Models
{
    public class Movie
    {
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Title { get; set; }
        public string FilmGenre { get; set; } = null!;
        public string? Director { get; set; }
        public int YearOfPremiere { get; set; }

        public Movie(string title, string filmgenre, string director, int yearofpremiere)
        {
            Title = title;
            FilmGenre = filmgenre;
            Director = director;
            YearOfPremiere = yearofpremiere;
        }
    }


}



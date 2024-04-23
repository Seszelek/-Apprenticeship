using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TestMovieExample;

using MoviesExample.Repo;
using MoviesExample.Models;
using MoviesExample.Controllers;

public class Tests
{
    private MoviesRepo _moviesRepo;
    
    [SetUp]
    public void Setup()
    {
        _moviesRepo = new MoviesRepo();
    }
    
    [Test]
    public void IsMovieInDatabase_ExistingMovie_ReturnsTrue()
    {
        Assert.IsTrue(_moviesRepo.IsMovieInDatabase("The Green Mile"));
    }

    [Test]
    public void AddNewMovie_AddsMovieToDatabase()
    {
        Movie newMovie = new Movie("The Godfather", "Drama", "Francis Ford Coppola", 1972);
        
        _moviesRepo.AddNewMovie(newMovie);
     
        Assert.That(_moviesRepo.movies.Any(x => x.Title == "The Godfather"), Is.True);
    }

    [Test]
    public void GetMovies_ReturnsListOfMovies()
    {
        var result = _moviesRepo.GetMovies();
        
        Assert.Multiple(() =>
        {
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<System.Collections.Generic.List<Movie>>(result);
            Assert.That(result.Count(), Is.EqualTo(3));
        });
    }

    [Test]
    public void ShowLastAddedMovie_ReturnsLastAddedMovie()
    {
        var result = _moviesRepo.ShowLastAddedMovie();
        var lastMovie = _moviesRepo.movies.Last();
    
        Assert.Multiple(() =>
        {
            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo(lastMovie));
        });
    }

    [Test]
    public void GetMovieGenre_ReturnsMoviesFromGivenGenre()
    {
        var result = _moviesRepo.GetMovieGenre("Science Fiction").ToList();
        
        Assert.Multiple(() =>
        {
            Assert.IsNotNull(result);
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.Any(x => x.Title == "Avatar"), Is.True);
        });
    }

    [Test]
    public void GetMovieYear_ReturnsOkResult()
    {
        var result = _moviesRepo.GetMovieYear(2009);
        var resultV2 = _moviesRepo.GetMovieYear(2889);
        
        Assert.Multiple(() =>
        {
            Assert.That(result.Any(), Is.True);
            Assert.That(resultV2.Any(), Is.False);
        });
    }
}
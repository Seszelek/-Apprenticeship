using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TestMovieExample;

using MoviesExample.Repo;
using MoviesExample.Models;
using MoviesExample.Controllers;

public class Tests
{
    private MoviesRepo _moviesRepo;
    // private MoviesController _controller;


    [SetUp]
    public void Setup()
    {
        _moviesRepo = new MoviesRepo();
        // _controller = new MoviesController(_moviesRepo);
    }


    [Test]
    public void IsMovieInDatabase_ExistingMovie_ReturnsTrue()
    {
        Assert.IsTrue(_moviesRepo.IsMovieInDatabase("The Green Mile"));
    }

    [Test]
    public void AddNewMovie_AddsMovieToDatabase()
    {
        // Arrange
        Movie newMovie = new Movie("The Godfather", "Drama", "Francis Ford Coppola", 1972);
        // Act
        _moviesRepo.AddNewMovie(newMovie);
        // Assert
        Assert.That(_moviesRepo.movies.Any(x => x.Title == "The Godfather"), Is.True);
    }

    [Test]
    public void GetMovies_ReturnsListOfMovies()
    {
        // Act
        var result = _moviesRepo.GetMovies();

        // Assert
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
        // Act
        var result = _moviesRepo.ShowLastAddedMovie();
        var lastMovie = _moviesRepo.movies.Last();
        // Assert
        Assert.Multiple(() =>
        {
            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo(lastMovie));
        });
    }

    [Test]
    public void GetMovieGenre_ReturnsMoviesFromGivenGenre()
    {
        // Act
        var result = _moviesRepo.GetMovieGenre("Science Fiction").ToList();

        // Assert
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
        // Act
        var result = _moviesRepo.GetMovieYear(2009);
        var resultV2 = _moviesRepo.GetMovieYear(2889);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Any(), Is.True);
            Assert.That(resultV2.Any(), Is.False);
        });
    }
}
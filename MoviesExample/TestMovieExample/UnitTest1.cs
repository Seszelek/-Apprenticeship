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
    public void TestCheckIfThisFilmIsInBase()
    {
        Assert.IsTrue(_moviesRepo.IsMovieInDatabase("The Green Mile"));
    }
    
}
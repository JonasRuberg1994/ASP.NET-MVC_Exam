using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TheMovieList.Repositories;
using TheMovieList.Controllers;
using TheMovieList.Models;

namespace TheMovieList.Tests
{
    [TestClass]
    public class TestMoviesController
    {
        [TestMethod]
        public void Test_MoviesControllerCreate_CallsInsertOrUpdate()
        {
            //Arrange - setting up the conditions for the test
            Mock<IMovieRepository> mockMovieRepo = new Mock<IMovieRepository>();

            MoviesController controller = new MoviesController(mockMovieRepo.Object);

            
            Movie movie1 = new Movie
            {
                Title = "James Bond",
                Year = 2011,
                Director = "Lars"
            };

            //Act - performing the test
            controller.Create(movie1);

            //Assert - Verifying that the result was the one that was required.
            mockMovieRepo.Verify(a => a.InsertOrUpdate(movie1));


        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheMovieList.Models;
using System.Linq;
using static TheMovieList.Models.Favorite;

namespace TheMovieList.Tests
{
    [TestClass]
    public class TestFavoritesController
    {
        [TestMethod]
        public void Can_Add_New_Lines()
        {
            //Arrange - create some test movies
            Movie p1 = new Movie { MovieId = 1, Title = "P1" };
            Movie p2 = new Movie { MovieId = 2, Title = "P2" };

            //Arrange - create a new favorite
            Favorite target = new Favorite();

            //Act - performing the test
            target.AddFavorite(p1, 1);
            target.AddFavorite(p2, 1);
            FavoriteLine[] results = target.Lines.ToArray();

            //Assert - Verifying that the result was the one that was required.
            Assert.AreEqual(results.Length, 2);
            Assert.AreEqual(results[0].Movie, p1);
            Assert.AreEqual(results[1].Movie, p2);
        }
    }
}

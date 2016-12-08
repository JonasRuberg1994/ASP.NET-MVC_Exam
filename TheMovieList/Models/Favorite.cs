using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheMovieList.Models
{
    public class Favorite
    {
        private List<FavoriteLine> lineCollection = new List<FavoriteLine>(); //A list that contains all the chosen favorites

        public void AddFavorite(Movie movie, int quantity)
        {
            FavoriteLine line = lineCollection
                .Where(p => p.Movie.MovieId == movie.MovieId) //Filters items that no not match the predicate
                .FirstOrDefault(); //return first item or the default value if there are no items

            if (line == null) //if empty
            {
                lineCollection.Add(new FavoriteLine { Movie = movie, Quantity = quantity }); //then add a movie to the favorites 
            }
            else
            {
                line.Quantity += quantity; //if it allready exist, dont duplicate
            }
        }

        public void RemoveLine(Movie movie)
        {
            lineCollection.RemoveAll(l => l.Movie.MovieId == movie.MovieId);
        }

        public IEnumerable<FavoriteLine> Lines
        {
            get { return lineCollection; }
        }

        public class FavoriteLine
        {
            public Movie Movie { get; set; } //Movie selected by the user
            public int Quantity { get; set; } //How many times he want to add it to the favorites 
        }

    }
}
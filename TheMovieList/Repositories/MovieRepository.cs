using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TheMovieList.Models;

namespace TheMovieList.Repositories
{
    public class MovieRepository : IMovieRepository //implementing the IMovieRepository Interface
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public void Delete(int id)
        {
            Movie movie = db.Movies.Find(id); //should return movie based on id
            db.Movies.Remove(movie); //delete the movie with the specific id
            db.SaveChanges(); //update the database
        }

        public Movie Find(int id)
        {
            return db.Movies.Find(id); //should return movie based on id
           
        }

        public IEnumerable<Movie> Movies
        {
            get {return db.Movies; } // return all the movies 
        }

        public void InsertOrUpdate(Movie movie)
        {
            if(movie.MovieId == 0)
            {
                db.Movies.Add(movie); //insert or update a movie
            }

            else
            {
                db.Entry(movie).State = EntityState.Modified;
            }

            db.SaveChanges(); //update the database
            
        }
    }
}
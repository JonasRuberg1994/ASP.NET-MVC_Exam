using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMovieList.Models;

namespace TheMovieList.Repositories
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> Movies { get; } //Return all the movies 
        Movie Find(int id); // should return one movie based on id
        void Delete(int id); // should delete a movie with the specific id
        void InsertOrUpdate(Movie movie); //should insert or update a movie to the database

    }
}

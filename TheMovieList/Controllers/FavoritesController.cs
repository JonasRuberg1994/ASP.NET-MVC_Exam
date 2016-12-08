using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheMovieList.Models;
using TheMovieList.Repositories;

namespace TheMovieList.Controllers
{
    public class FavoritesController : Controller
    {
        //Dependency Injecton 
        private IMovieRepository movieRepo;

        //creating the mock
        public FavoritesController(IMovieRepository repo)
        {
            this.movieRepo = repo;
        }

        public RedirectToRouteResult AddToFavorites(int movieId, string returnUrl) //RedirectToRouteResult - issues a redirect to another action
        {
            Movie movie = movieRepo.Movies.FirstOrDefault(p => p.MovieId == movieId); //return the first item or the default value if there are no items

            if (movie != null)
            {
                GetFavorite().AddFavorite(movie, 1); //Add a favorite
            }

            return RedirectToAction("Index", new { returnUrl }); //call the Index action method of the Cart controller.
        }

        public RedirectToRouteResult RemoveFromFavorite (int movieId, string returnUrl) //RedirectToRouteResult - issues a redirect to another action
        {
            Movie movie = movieRepo.Movies.FirstOrDefault(p => p.MovieId == movieId); //return the first item or the default value if there are no items

            if (movie != null) //if there are movies 
            {
                GetFavorite().RemoveLine(movie); //Remove the favorite the user have chosen
            }

            return RedirectToAction("Index", new { returnUrl }); //call the Index action method of the Cart controller.
        }

        private Favorite GetFavorite()
        {
            Favorite favorite = (Favorite)Session["Favorite"]; //To add an object to the session state
            if (favorite == null)
            {
                favorite = new Favorite(); 
                Session["Favorite"] = favorite;  //Retrive an object 
            }
            return favorite;
        }



        // GET: Favorites
        public ViewResult Index(string returnUrl) //Viewresult - renders a complete webpage
        {
            return View(new FavoriteIndex
            {
                Favorite = GetFavorite(),
                ReturnUrl = returnUrl
            });
        }

    }
}
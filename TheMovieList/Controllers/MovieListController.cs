using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheMovieList.Models;

namespace TheMovieList.Controllers
{
    public class MovieListController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: MovieList
        public ActionResult Index(string searchBy, string search)
        {
            //search by title
            if (searchBy == "Title")
            {
                return View(db.Movies.Where(x => search == null || x.Title.ToLower().Contains(search.ToLower())).ToList());
            }

            //search by director
            else
            {
                return View(db.Movies.Where(x => search == null || x.Director.ToLower().Contains(search.ToLower())).ToList());
            }

        }
    }
}
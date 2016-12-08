using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheMovieList.Models;
using TheMovieList.Repositories;

namespace TheMovieList.Controllers
{
    //Login
    //username : admin@test.com
    //password : passW0rd! 

    //[Authorize(Roles = "Admin")]
    public class MoviesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //Dependency injection
        private IMovieRepository movieRepo;

        //an instance of some class that implements an interface called IMovieRepository. 
        //this may connect to real data in a DB or fake, in memory-data

        //creating the mock
        public MoviesController(IMovieRepository repo) 
        {
            this.movieRepo = repo;
        }


        public ActionResult Index(string searchBy, string search)
        {
            //Where - filters items from the data source that do not match the predicate
            //Contains - returns true if the data source contains a specific item or value

            //search by title
            if (searchBy == "Title")
            {
                return View(movieRepo.Movies.Where(x => search == null || x.Title.ToLower().Contains(search.ToLower())).ToList());
            }

            //search by director
            else 
            {
                return View(movieRepo.Movies.Where(x => search == null || x.Director.ToLower().Contains(search.ToLower())).ToList());
            }

        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            return View(movieRepo.Find(id)); //should return one movie based on id
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieId,Title,Year,Director,CategoryId")] Movie movie)
        {
            //If no broken rules in Movie Model
            if (ModelState.IsValid)
            {
                movieRepo.InsertOrUpdate(movie); //should insert or update a movie to the database
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", movie.CategoryId); //drop
            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int id)
        {
            Movie movie = movieRepo.Find(id); //should return one movie based on id

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", movie.CategoryId);
            return View(movie);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieId,Title,Year,Director,CategoryId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                movieRepo.InsertOrUpdate(movie); //should insert or update a movie to the database
                return RedirectToAction("Index"); //return to the index page
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", movie.CategoryId);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int id)
        {
            return View(movieRepo.Find(id)); //should return one movie based on id
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            movieRepo.Delete(id); // should delete a movie with the specific id

            return RedirectToAction("Index"); //return to the index page
        }
    }
}

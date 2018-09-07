using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myMVC.Models;
using myMVC.ViewModels;

namespace myMVC.Controllers
{
    public class MoviesController : Controller
    {

        //GET: Movies/Random
        //public ViewResult Random1()           
        public ActionResult Random1()
        {
            var movie = new Movie() { Name = "VASA", Id=1 };
            var customers = new List<Customer>
                        {
                                 new Customer {CustName="Harsh"},
                                 new Customer {CustName="Saini"}
                        };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            //ViewData["Movie"] = movie;
            //ViewBag.Movie = movie;

            // Another way of calling the view
            //ViewResult viewResult = new ViewResult();
            //viewResult.ViewData.Model = movie;
            return View(viewModel);


           // return Content("Hello World");
            //http://localhost:55920/Movies/Random1
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { Page = 1, sortBy = "name" });
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if (string.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }
            var movies = new Movies();
            var allMivies = new List<Movie>();
            allMivies.Add(new Movie { Name = "Enemy at the Gates", Id = 1 });
            allMivies.Add(new Movie { Name = "Krish", Id = 2 });
            //allMivies.Sort();
            movies.AllMovies = allMivies;
            return View(movies);

            //return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }


        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(string.Format(year + "/" + month));
        }


        ////[Route("movies/}")]
        //public ActionResult AllMovies(int year, int month)
        //{
        //    var movies = new Movies();
        //    movies.AllMovies.Add(new Movie { Name = "Enemy at the Gates", Id = 1 });
        //    movies.AllMovies.Add(new Movie { Name = "Krish", Id = 2 });
        //    return View(movies);
        //}
    }
}
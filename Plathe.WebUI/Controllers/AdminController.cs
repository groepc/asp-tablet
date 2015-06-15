using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;

namespace Plathe.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IMovieRepository repository;

        public AdminController(IMovieRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Movies);
        }

        public ViewResult Edit(int id)
        {
            Movie movie = repository.Movies.FirstOrDefault(p => p.MovieId == id);
            return View(movie);
        }
    }
}
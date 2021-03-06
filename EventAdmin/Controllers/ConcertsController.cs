﻿using EventAdmin.Models;
using EventAdmin.ViewModels;
using Microsoft.AspNet.Identity;
using Ninject;
using System.Linq;
using System.Web.Mvc;

namespace EventAdmin.Controllers
{
    public class ConcertsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        IKernel kernel = new StandardKernel(new DIModule("DbContext"));

        public ConcertsController()
        {
            _dbContext = kernel.Get<ApplicationDbContext>();
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new ConcertFormViewModel
            {
                Genres = _dbContext.Genres.ToList()
            };

            return View(viewModel);
        }

        [Authorize, HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(ConcertFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _dbContext.Genres.ToList();
                return View("Create", viewModel);
            }
            var concert = new Concert
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };

            _dbContext.Concerts.Add(concert);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Home");

        }
    }
}
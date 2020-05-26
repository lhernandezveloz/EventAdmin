using EventAdmin.Models;
using EventAdmin.ViewModels;
using Microsoft.AspNet.Identity;
using Ninject;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace EventAdmin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _DbContext;
        IKernel kernel = new StandardKernel(new DIModule("DbContext"));

        public HomeController()
        {
            _DbContext = kernel.Get<ApplicationDbContext>();

        }

        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var concerts = _DbContext.Concerts
                .Include(x => x.Artist)
                .Include(x => x.Genre)
                .Where(x => x.DateTime > DateTime.Now)
                .Select(c => new ConcertAttendeeViewModel
                {
                    Id = c.Id,
                    Artist = c.Artist.FirstName + " " + c.Artist.LastName,
                    DateTime = c.DateTime,
                    Genre = c.Genre.Name,
                    Venue = c.Venue,
                    IsAttending = _DbContext.Attendances.Any(a => a.ConcertId == c.Id && a.AttendeeId == userId)
                }).ToList();

            return View(concerts);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
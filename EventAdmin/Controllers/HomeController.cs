using EventAdmin.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace EventAdmin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _DbContext;
        public HomeController()
        {
            _DbContext = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Index()
        {
            var concerts = _DbContext.Concerts
                .Include(x => x.Artist)
                .Where(x => x.DateTime > DateTime.Now);

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
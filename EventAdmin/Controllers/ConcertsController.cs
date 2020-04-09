using EventAdmin.Models;
using EventAdmin.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace EventAdmin.Controllers
{
    public class ConcertsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ConcertsController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public ActionResult Create()
        {
            var viewModel = new ConcertFormViewModel
            {
                Genres = _dbContext.Genres.ToList()
            };

            return View(viewModel);
        }
    }
}
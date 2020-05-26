using EventAdmin.DTOs;
using EventAdmin.Models;
using Microsoft.AspNet.Identity;
using Ninject;
using System.Linq;
using System.Web.Http;


namespace EventAdmin.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private readonly ApplicationDbContext _DbContext;
        IKernel kernel = new StandardKernel(new DIModule("DbContext"));

        private readonly string userId;

        public AttendancesController()
        {
            _DbContext = kernel.Get<ApplicationDbContext>();
            userId = User.Identity.GetUserId();
        }
        public IHttpActionResult Get(ConcertDTO dto)
        {

            if (_DbContext.Attendances.Any(x => x.ConcertId == dto.ConcertId && x.AttendeeId == userId))
            {
                return Ok();
            }
            return BadRequest("Attendee already exists.");

        }

        // POST api/<controller>
        public IHttpActionResult Post(ConcertDTO dto)
        {

            var attendance = _DbContext.Attendances.Where(x => x.ConcertId == dto.ConcertId && x.AttendeeId == userId).FirstOrDefault();
            if (attendance != null)
            {
                _DbContext.Attendances.Remove(attendance);
                _DbContext.SaveChanges();

                return Ok("Removed");
            }

            var attendee = new Attendance
            {
                ConcertId = dto.ConcertId,
                AttendeeId = userId
            };

            _DbContext.Attendances.Add(attendee);
            _DbContext.SaveChanges();

            return Ok();
        }
    }
}

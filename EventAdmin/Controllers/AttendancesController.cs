using EventAdmin.DTOs;
using EventAdmin.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;


namespace EventAdmin.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private readonly ApplicationDbContext _DbContext;
        private readonly string userId;
        public AttendancesController()
        {
            _DbContext = new ApplicationDbContext();
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

            if (_DbContext.Attendances.Any(x => x.ConcertId == dto.ConcertId && x.AttendeeId == userId))
            {
                return BadRequest("Attendee already exists.");
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

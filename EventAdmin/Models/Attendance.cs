using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventAdmin.Models
{
    public class Attendance
    {
        public Concert Concert { get; set; }

        [Key, Column(Order = 1)]
        public int ConcertId { get; set; }
        public ApplicationUser Attendee { get; set; }

        [Key, Column(Order = 2)]
        public string AttendeeId { get; set; }
    }
}
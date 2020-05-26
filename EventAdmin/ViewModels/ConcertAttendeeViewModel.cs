using System;

namespace EventAdmin.ViewModels
{
    public class ConcertAttendeeViewModel
    {
        public int Id { get; set; }

        public string Artist { get; set; }

        public string Venue { get; set; }

        public DateTime DateTime { get; set; }

        public string Genre { get; set; }

        public bool IsAttending { get; set; }
    }
}
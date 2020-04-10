using EventAdmin.Models;
using System;
using System.Collections.Generic;

namespace EventAdmin.ViewModels
{
    public class ConcertFormViewModel
    {
        public string Venue { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int Genre { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

        public DateTime GetDateTime() => DateTime.Parse($"{Date} {Time}");
    }
}
using EventAdmin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventAdmin.ViewModels
{
    public class ConcertFormViewModel
    {
        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [ValidateTime]
        public string Time { get; set; }

        [Required]
        public int Genre { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public DateTime GetDateTime() => DateTime.Parse($"{Date} {Time}");
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace EventAdmin.Models
{
    public class Concert
    {
        public int Id { get; set; }

        public ApplicationUser Artist { get; set; }

        [Required]
        public string ArtistId { get; set; }

        [Required, MaxLength(255)]
        public string Venue { get; set; }

        public DateTime DateTime { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public int GenreId { get; set; }
    }
}
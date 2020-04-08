using System;
using System.ComponentModel.DataAnnotations;

namespace EventAdmin.Models
{
    public class Concert
    {
        public int Id { get; set; }

        [Required, MaxLength(225)]
        public ApplicationUser Artist { get; set; }

        [Required, MaxLength(255)]
        public string Venue { get; set; }

        public DateTime DateTime { get; set; }

        [Required, MaxLength(255)]
        public Genre Genre { get; set; }
    }
}
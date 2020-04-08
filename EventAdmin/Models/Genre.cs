using System.ComponentModel.DataAnnotations;

namespace EventAdmin.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Required, MaxLength(225)]
        public string Name { get; set; }
    }
}
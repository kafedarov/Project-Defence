using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookLibrary.Models
{
    public class Book
    {
        
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(100)]
        public string Author { get; set; }
        [Required]
        [StringLength(100)]
        public string Publisher { get; set; }
        [StringLength(100)]
        public string ImagePath { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public int Price { get; set; }

    }
}

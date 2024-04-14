using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookLibrary.Models
{
    public class Genre
    {
       
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public IEnumerable<Book> Books { get; set; }


    }
}

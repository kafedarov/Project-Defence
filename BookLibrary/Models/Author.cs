using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookLibrary.Models
{
    public class Author
    {
        //This model will be modified and used in next quarters class
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public string BirthDate { get; set; }
        public string Description { get; set; }
    }
}

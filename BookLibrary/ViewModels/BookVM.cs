using BookLibrary.Models;
using BookLibrary.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BookLibrary.ViewModels
{
    public class BookVM
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

        [Display(Name = "Upload Photo")]
    

        public IFormFile BookImage { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Price")]
        public int Price { get; set; }


    }
}

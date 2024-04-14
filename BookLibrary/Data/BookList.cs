using BookLibrary.Models;
using System.Collections.Generic;

namespace BookLibrary.Data
{
    //This class was used just for testing
    public class BookList : IBookList
    {
        int idCounter = 1;
        List<Book> books;

        Random random = new Random();

        public BookList()
        {
            books = new List<Book>
            {
                new Book { Id = idCounter++, Title = "Red Rising", Author = "Pierce Brown", Publisher = "Del Rey", ImagePath="RedRising.jpg", GenreId = 1 },
                new Book { Id = idCounter++, Title = "Pet Sematary", Author = "Stephen King", Publisher = "Gallery", ImagePath="PetSematary.jpg", GenreId = 2},
                new Book { Id = idCounter++, Title = "Dune", Author = "Frank Herbert", Publisher = "Ace", ImagePath="dune.jpg", GenreId = 1},
                new Book { Id = idCounter++, Title = "HTML & CSS: Design and Build Websites", Author = "Jon Duckett", Publisher = "Wiley", ImagePath="HtmlCss.jpg", GenreId = 4 },
                new Book { Id = idCounter++, Title = "Python Crash Course: A Hands On, Project-Based Introduction to Programming", Author = "Eric Matthes", Publisher = "No Starch Press", ImagePath="PythonCrashCourse.jpg", GenreId = 4 },
                new Book { Id = idCounter++, Title = "The Devil In the White City: Murder, Magic, and Madness at the Fair That Changed America", Author = "Erik Larson", Publisher = "Vintage", ImagePath="DevilWhiteCity.jpg", GenreId = 3 }
            };
        }

        public List<Book> GetBooks() { return books; }  
    }
}

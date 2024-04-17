using BookLibrary.Models;

namespace BookLibrary.Data
{
    //This class was just used for testing
    public class GenreList : IGenreList
    {
        List<Genre> genres;

        public GenreList()
        {
            genres = new List<Genre>
            {
                new Genre { Id = 1, Name = "Sci-Fi" },
                new Genre { Id = 2, Name = "Horror" },
                new Genre { Id = 3, Name = "True Crime" },
                new Genre { Id = 4, Name = "Technology" }
            };

        }

        public List<Genre> GetGenres()
        {
            return genres;
        }
    }
}

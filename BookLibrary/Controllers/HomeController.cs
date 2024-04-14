using BookLibrary.Data;
using BookLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BookLibrary.Controllers
{

    public class HomeController : Controller
    {
        BookLibraryDb _bookDb;

        public HomeController(BookLibraryDb bookLibrary)
        {
            _bookDb = bookLibrary;
        }
        public IActionResult Aboutus()
        {
            return View();  
        }
		private SelectList GetGenres()
		{
			IEnumerable<string> genreNames = _bookDb.Genres.Select(g => g.Name).Distinct();
			SelectList selectGenre = new SelectList(genreNames);

			return selectGenre;
		}
		[HttpGet]
		public IActionResult All(string genreName, string userSearch)
		{
			IEnumerable<Book> booksAndGenre = _bookDb.Books.Include(b => b.Genre).ToList();
			ViewBag.genreList = GetGenres();

			var searchResults = booksAndGenre;

			if (genreName != null)
			{
				searchResults = booksAndGenre.Where(b => b.Genre.Name == genreName);
			}

			if (userSearch != null)
			{
				searchResults = booksAndGenre.Where(b => b.Title.ToUpper().Contains(userSearch.ToUpper()));
			}
            ViewBag.recentBooks = searchResults.ToList();
			return View("ViewbyCategoury");
		}



		[HttpPost]

        public IActionResult contactusPOST(Contactus model)
        {
            _bookDb.Add(model);
            _bookDb.SaveChanges();
            ViewBag.status = "Successfully submitted!";
            Contactus cantact=new Contactus();
            return View("contactus", cantact);  
        }

        public IActionResult Contactus()
        {
            return View();
        }


        //Action for homepage content
        public IActionResult Index(string genreName)
        {
            IEnumerable<Book> booksAndGenre = _bookDb.Books.Include(b => b.Genre).ToList();

            IEnumerable<Book> sortedByDateAdded = booksAndGenre.OrderByDescending(b => b.DateAdded).Take(4).ToList();
            ViewBag.recentBooks = sortedByDateAdded;

			IEnumerable<Book> books = booksAndGenre.OrderByDescending(b => b.DateAdded).ToList();
			ViewBag.Books = books;


			IEnumerable<string> genres = _bookDb.Genres.Select(g => g.Name).Distinct();
            SelectList selectGenre = new SelectList(genres, genreName);
            ViewBag.genreList = selectGenre;

            return View(booksAndGenre);
        }

        public IActionResult ViewbyCategoury(int CategouryID)
        {

			IEnumerable<Book> booksAndGenre = _bookDb.Books.Where(x=>x.GenreId==CategouryID).Include(b => b.Genre).ToList();
            Genre Gens=_bookDb.Genres.Where(x=>x.Id==CategouryID).FirstOrDefault(); 
            ViewBag.Categourytitle = Gens.Name;
			IEnumerable<Book> sortedByDateAdded = booksAndGenre.OrderByDescending(b => b.DateAdded).Take(4).ToList();
			ViewBag.recentBooks = booksAndGenre;

			IEnumerable<string> genres = _bookDb.Genres.Select(g => g.Name).Distinct();
			SelectList selectGenre = new SelectList(genres, "genreName");
			ViewBag.genreList = selectGenre;

			return View(booksAndGenre);
		}

        //Action to Coming Soon/Under Construction Page
        public IActionResult UnderConstruction()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
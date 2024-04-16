using BookLibrary.Data;
using Microsoft.AspNetCore.Mvc;
using BookLibrary.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using BookLibrary.ViewModels;
using System.Xml.Linq;
using Microsoft.AspNetCore.Authorization;

namespace BookLibrary.Controllers
{
    public class CatalogController : Controller
    {
        
        BookLibraryDb _bookDb;
        IWebHostEnvironment _environment;

        public CatalogController(BookLibraryDb bookLibrary, IWebHostEnvironment environment)
        {
            _bookDb = bookLibrary;
            _environment = environment;
        }


        //Catalog to All Books In Database
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

            if(userSearch != null)
            {
                searchResults = booksAndGenre.Where(b => b.Title.ToUpper().Contains(userSearch.ToUpper()));
            }

            return View(searchResults.ToList());
        }


        //Actions for Creating a New Book
        [Authorize(Roles ="admin")]
        [HttpGet]
        public IActionResult Create()
        {

            ViewBag.genreList = GetGenres();

            BookVM model = new BookVM();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(BookVM b, string selectedGenre)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.genreList = GetGenres();
                return View(b);
            }

            string imgFileName = SaveUploadedFile(b.BookImage) ;
            Genre g = _bookDb.Genres.SingleOrDefault(x => x.Name == selectedGenre);
            Book book = new Book
                {
                    Title = b.Title,
                    Author = b.Author,
                    Publisher = b.Publisher,
                    ImagePath = imgFileName,
                    Genre = g,
                    GenreId = g.Id
                };
                
                _bookDb.Books.Add(book);
                _bookDb.SaveChanges();
              
            return Redirect($"Details/{book.Id}");
        }




		//Actions For Editing/Updating a Book
		[Authorize(Roles = "admin")]
		[HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Book editBook = _bookDb.Books.SingleOrDefault(b => b.Id == id);
            BookVM bookVM = new BookVM();

            if (editBook == null)
            {
                return NotFound();
            }
            else
            {
                bookVM.Id = editBook.Id;
                bookVM.Title = editBook.Title;
                bookVM.Author = editBook.Author;
                bookVM.Publisher = editBook.Publisher;
                bookVM.ImagePath = editBook.ImagePath;
                bookVM.Genre = editBook.Genre;
                bookVM.GenreId = editBook.GenreId;
                bookVM.Price = editBook.Price;
            }

            IEnumerable<string> genreNames = _bookDb.Genres.Select(g => g.Name).Distinct();
            SelectList selectGenre = new SelectList(genreNames);

            ViewBag.genreList = selectGenre;

            return View(bookVM);
        }
        [HttpPost]
        public IActionResult Edit(BookVM b, string selectedGenre)
        {
            string imgFileName = "";

			if (!ModelState.IsValid)
            {
                ViewBag.genreList = GetGenres();
                return View(b);
            }
            if (b.ImagePath != null)
            {
                 imgFileName = SaveUploadedFile(b.BookImage);
            }
            else
            {
				 imgFileName=_bookDb.Books.Where(x=>x.Id==b.Id).FirstOrDefault().ImagePath;

			}
            Genre g = _bookDb.Genres.SingleOrDefault(x => x.Name == selectedGenre);

            IEnumerable<Book> booksAndGenre = _bookDb.Books.Include(b => b.Genre).ToList();
            Book editBook = _bookDb.Books.SingleOrDefault(x => x.Id == b.Id);

            if (editBook == null)
            {
                return NotFound();
            }
            else
            {
                editBook.Id = b.Id;
                editBook.Title = b.Title;
                editBook.Author = b.Author;
                editBook.Publisher = b.Publisher;
                editBook.ImagePath = imgFileName;
                editBook.Genre = g;
                editBook.GenreId = g.Id;
                _bookDb.Books.Update(editBook);
                _bookDb.SaveChanges();
            }
            
            return RedirectToAction("Details", new {editBook.Id});
        }



        //Action to get the Details of a Book
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            else if (_bookDb.Books == null)
            {
                return NotFound();
            }

            IEnumerable<Book> booksAndGenre = _bookDb.Books.Include(b => b.Genre).ToList();

            Book bk = booksAndGenre.SingleOrDefault(b => b.Id == id);

            return View(bk);
        }



		//Actions to Delete a Book
		[Authorize(Roles = "admin")]
		[HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Book b = _bookDb.Books.SingleOrDefault(x => x.Id == id);

            if (b is null)
            {
                return NotFound();
            }

            return View(b);
        }

        [HttpPost]
        public IActionResult Delete(Book b)
        {
            if (b.Id == 0)
            {
                return NotFound();
            }

            Book deleteBook = _bookDb.Books.SingleOrDefault(x => x.Id == b.Id);

            if (deleteBook is null)
            {
                return NotFound();
            }

            _bookDb.Books.Remove(deleteBook);
            _bookDb.SaveChanges();

            return RedirectToAction("All");
        }



        //Method that saves the image file to img folder and returns the file name
        private string SaveUploadedFile(IFormFile file)
        {
            if (file != null)
            {
                //Gets the relative path from the webHostEnvironment
                string folder = Path.Combine(_environment.WebRootPath, "img");
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string filePath = Path.Combine(folder, fileName);

                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fs);
                }
                return fileName;
            }
            return "";
        }


        //Method that returns a selectlist of genres to be used in different actions 
        private SelectList GetGenres()
        {
            IEnumerable<string> genreNames = _bookDb.Genres.Select(g => g.Name).Distinct();
            SelectList selectGenre = new SelectList(genreNames);

            return selectGenre;
        }

       
    }
}

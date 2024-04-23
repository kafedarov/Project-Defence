using BookLibrary.Data;
using BookLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BookShop.Controllers
{

    public class ContactController : Controller
    {
        BookLibraryDb _bookDb;
      
        public ContactController(BookLibraryDb bookLibrary)
        {
            _bookDb = bookLibrary;
        }

        [HttpPost]

        public IActionResult contactusPOST(Contactus model)
        {
            _bookDb.Add(model);
            _bookDb.SaveChanges();
            ViewBag.status = "Successfully submitted!";
            Contactus cantact=new Contactus();
            return View("contact", cantact);  
        }

        public IActionResult Contactus()
        {
            return View("Contact");
        }

    }
}
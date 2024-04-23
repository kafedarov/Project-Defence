using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
	public class ExtraController : Controller
	{
		//Action to Coming Soon/Under Construction Page
		public IActionResult UnderConstruction()
		{
			return View();
		}

        public IActionResult Aboutus()
        {
            return View();
        }

        public IActionResult Privacy()
		{
			return View();
		}

        public IActionResult Faqs()
        {
            return View();
        }
    }
}

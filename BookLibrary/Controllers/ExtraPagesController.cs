using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
	public class ExtraPagesController : Controller
	{
		//Action to Coming Soon/Under Construction Page
		public IActionResult UnderConstruction()
		{
			return View();
		}


		public IActionResult Privacy()
		{
			return View();
		}
	}
}

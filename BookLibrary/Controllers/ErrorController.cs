using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
	public class ErrorController : Controller
	{
        [Route("Error/404")]
        public IActionResult Error404()
        {
            return View("NotFound");
        }

        [Route("Error/500")]
        public IActionResult Error500()
        {
            return View("InternalError");
        }

        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    return View("NotFound");
                case 500:
                    return View("InternalError");
                default:
                    return View("GenericError");
            }
        }

        public IActionResult NotFound()
        {
            return View();
        }

        public IActionResult InternalError()
        {
            return View();
        }
    }
}

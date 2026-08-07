using Microsoft.AspNetCore.Mvc;

namespace Recept.Controllers
{
    public class VeggieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Grillspett()
        {
            return View();
        }

        public IActionResult VeggieGulasch()
        {
            return View();
        }

        public IActionResult Wellington()
        {
            return View();
        }

    }
}

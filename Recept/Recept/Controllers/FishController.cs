using Microsoft.AspNetCore.Mvc;

namespace Recept.Controllers
{
    public class FishController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult FishAndChips()
        {
            return View();
        }
        public IActionResult Smorgastarta()
        {
            return View();
        }
        public IActionResult Tonfisk()
        {
            return View();
        }
        public IActionResult Stromming()
        {
            return View();
        }

        public IActionResult Lojromspizza()
        {
            return View();
        }

        public IActionResult Gos()
        {
            return View();


        }
        public IActionResult Laxpaj()
        {
            return View();

        }
        public IActionResult Fiskgryta()
        {
            return View();
        }
    }
}

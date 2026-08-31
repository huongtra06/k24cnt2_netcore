using Microsoft.AspNetCore.Mvc;

namespace LHTraLesson4.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Name = "Lường Hương Trà ";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
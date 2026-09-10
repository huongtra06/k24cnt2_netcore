using Microsoft.AspNetCore.Mvc;

namespace LQThangLesson4.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Name = "Lê Quang Thắng";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
using Microsoft.AspNetCore.Mvc;

namespace LHTLesson13.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

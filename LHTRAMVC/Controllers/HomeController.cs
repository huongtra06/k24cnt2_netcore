using LHTRAMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace LHTRAMVC.Controllers
{
    public class HomeController : Controller
    {
        // Trang chủ
        public IActionResult Index()
        {
            var products = ProductData.GetProducts();

            return View(products);
        }

        // Trang Giới thiệu
        public IActionResult About()
        {
            return View();
        }

        // Trang Liên hệ
        public IActionResult Contact()
        {
            return View();
        }
    }
}
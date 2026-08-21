using LHTRAMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace LHTRAMVC.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var products = ProductData.GetProducts();

            return View(products);
        }

        public IActionResult Details(int id)
        {
            var products = ProductData.GetProducts();

            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
using Microsoft.AspNetCore.Mvc;

namespace LHTLesson_13.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

       
            public IActionResult Search(string keyword)
        {
            var products = new List<(int Id, string Name, string Price)>
    {
        (1, "Mô hình Gundam", "350.000 VNĐ"),
        (2, "Mô hình One Piece", "450.000 VNĐ"),
        (3, "Mô hình Dragon Ball", "390.000 VNĐ"),
        (4, "Mô hình Naruto", "420.000 VNĐ")
    };

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                products = products
                    .Where(p => p.Name.Contains(keyword,
                        StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            ViewBag.Keyword = keyword;

            return View(products);
        }
        

        public IActionResult Hot()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}
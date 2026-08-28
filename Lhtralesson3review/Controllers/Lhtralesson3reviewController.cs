using Microsoft.AspNetCore.Mvc;
using Lhtralesson3review.Models;

namespace Lhtralesson3review.Controllers
{
    public class Lhtralesson3reviewController : Controller
    {
        private readonly List<LHTRAProduct> _product = new()
        {
            new LHTRAProduct
            {
                LHTRAProductId = "LHTRA001",
                LHTRAProductName = "Laptop DEll inpresion 234234 i5-13450H ",
                LHTRAYearRelease = "2023",
                LHTRAProductNumber = 25000000
            },

            new LHTRAProduct
            {
                LHTRAProductId = "LHTRA002",
                LHTRAProductName = "iPhone 15 Pro",
                LHTRAYearRelease = "2023",
                LHTRAProductNumber = 5000000
            },

            new LHTRAProduct
            {
                LHTRAProductId = "LHTRA003",
                LHTRAProductName = "Samsung Galaxy S24 Ultra",
                LHTRAYearRelease = "2024",
                LHTRAProductNumber = 3000000
            },

            new LHTRAProduct
            {
                LHTRAProductId = "LHTRA004",
                LHTRAProductName = "MacBook Air M3",
                LHTRAYearRelease = "2024",
                LHTRAProductNumber = 20000000
            },

            new LHTRAProduct
            {
                LHTRAProductId = "LHTRA005",
                LHTRAProductName = "iPad Pro M4",
                LHTRAYearRelease = "2024",
                LHTRAProductNumber = 15000000
            },

            new LHTRAProduct
            {
                LHTRAProductId = "LHTRA006",
                LHTRAProductName = "Sony PlayStation 5",
                LHTRAYearRelease = "2020",
                LHTRAProductNumber = 40000000
            },

            new LHTRAProduct
            {
                LHTRAProductId = "LHTRA007",
                LHTRAProductName = "Nintendo Switch OLED",
                LHTRAYearRelease = "2021",
                LHTRAProductNumber = 35000000
            },

            new LHTRAProduct
            {
                LHTRAProductId = "LHTRA008",
                LHTRAProductName = "Apple Watch Series 9",
                LHTRAYearRelease = "2023",
                LHTRAProductNumber = 60000000
            },

            new LHTRAProduct
            {
                LHTRAProductId = "LHTRA009",
                LHTRAProductName = "Samsung Galaxy Tab S9",
                LHTRAYearRelease = "2023",
                LHTRAProductNumber = 18000000
            },

            new LHTRAProduct
            {
                LHTRAProductId = "LHTRA010",
                LHTRAProductName = "ASUS ROG Strix G16",
                LHTRAYearRelease = "2024",
                LHTRAProductNumber = 1200000000
            }
        };

        public IActionResult Index()
        {
            return Json(_product);
        }

        public IActionResult LHTRAGetAllProduct()
        {
            ViewData["products"] = _product;
            return View();
        }

        public IActionResult LHTRAGetListProduct()
        {
            return View(_product);
        }
    }
}
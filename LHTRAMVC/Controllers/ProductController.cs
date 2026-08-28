using LHTRAMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace LHTRAMVC.Controllers
{
    public class ProductController : Controller
    {
        // =========================
        // DANH SÁCH SẢN PHẨM
        // =========================
        public IActionResult Index()
        {
            var products = ProductData.GetProducts();

            return View(products);
        }

        // =========================
        // XEM CHI TIẾT
        // =========================
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

        // =========================
        // THÊM - GET
        // =========================
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // =========================
        // THÊM - POST
        // =========================
        [HttpPost]
        public IActionResult Create(Product product)
        {
            var products = ProductData.GetProducts();

            product.Id = products.Count == 0
                ? 1
                : products.Max(p => p.Id) + 1;

            product.CreatedAt = DateTime.Now;

            products.Add(product);

            // Lưu dữ liệu
            ProductData.SaveProducts(products);

            return RedirectToAction("Index");
        }

        // =========================
        // SỬA - GET
        // =========================
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var products = ProductData.GetProducts();

            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // =========================
        // SỬA - POST
        // =========================
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            var products = ProductData.GetProducts();

            var oldProduct = products.FirstOrDefault(p => p.Id == product.Id);

            if (oldProduct == null)
            {
                return NotFound();
            }

            oldProduct.Name = product.Name;
            oldProduct.Price = product.Price;
            oldProduct.ImageUrl = product.ImageUrl;

            // Lưu dữ liệu
            ProductData.SaveProducts(products);

            return RedirectToAction("Index");
        }

        // =========================
        // XÓA
        // =========================
        public IActionResult Delete(int id)
        {
            var products = ProductData.GetProducts();

            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            products.Remove(product);

            // Lưu dữ liệu
            ProductData.SaveProducts(products);

            return RedirectToAction("Index");
        }
    }
}
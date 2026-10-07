using LHTLesson15.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LHTLesson15.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string username, string password)
        {
            if (username == "huongtra" && password == "123456")
            {
                HttpContext.Session.SetString("username", username);

                TempData["Success"] = "Đăng nhập thành công!";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.MsgLogin = "Tên đăng nhập hoặc mật khẩu không đúng!";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");

            TempData["Success"] = "Đã đăng xuất thành công!";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult TestTempData()
        {
            TempData["Success"] = "TempData: Thao tác đã thực hiện thành công!";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}

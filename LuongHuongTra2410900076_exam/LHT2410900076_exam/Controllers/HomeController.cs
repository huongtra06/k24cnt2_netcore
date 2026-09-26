using LHT2410900076_exam.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LHT2410900076_exam.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction(nameof(LHTAbout));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult LHTAbout()
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

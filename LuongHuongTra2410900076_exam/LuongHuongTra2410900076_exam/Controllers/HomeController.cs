using Microsoft.AspNetCore.Mvc;

namespace LuongHuongTra2410900076_exam.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult LhtAbout()
    {
        return View();
    }

    public IActionResult Error()
    {
        return View();
    }
}

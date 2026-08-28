using Microsoft.AspNetCore.Mvc;
using Lhtralesson3review.Models;

namespace Lhtralesson3review.Controllers
{
    
    public class LhtraProductController : Controller
    {
        private readonly List<LHTRAProduct> _product = new()
        {
                  };

      
        public IActionResult LhtraGetAllProduct()
        {
            ViewData["products"] = _product;
            return View(); 
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using LHTraLesson06.Models;

namespace LHTraLesson06.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int? n)
        {
            List<Category> categories = new List<Category>
            {
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Máy Tính",
                    IsActive = true
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "SmartPhone",
                    IsActive = true
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Máy Tính bảng",
                    IsActive = false
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "Đồng Hồ",
                    IsActive = true
                }
            };
            n = n ?? 0;
            var search = categories.Where(c => c.CategoryId > n).ToList();
            return View(search);
        }
    }
}
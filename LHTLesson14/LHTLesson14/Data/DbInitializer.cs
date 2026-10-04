using LHTLesson14.Models;
using Microsoft.EntityFrameworkCore;

namespace LHTLesson14.Data;

public static class DbInitializer
{
    public static async Task InitializeAsync(LHTLesson14Context db)
    {
        await db.Database.EnsureCreatedAsync();

        if (!await db.Categories.AnyAsync())
        {
            var categories = new[]
            {
                new Category { Name = "Bánh kem sinh nhật", Description = "Bánh kem tươi dành cho sinh nhật và các buổi tiệc." },
                new Category { Name = "Bánh kem tình yêu", Description = "Bánh kem ngọt ngào dành tặng người thương." },
                new Category { Name = "Bánh mousse", Description = "Mousse mềm mịn, vị thanh nhẹ và dễ ăn." },
                new Category { Name = "Bánh mini", Description = "Bánh kem mini nhỏ xinh, phù hợp làm quà tặng." }
            };

            await db.Categories.AddRangeAsync(categories);
            await db.SaveChangesAsync();

            var birthday = categories[0].Id;
            var love = categories[1].Id;
            var mousse = categories[2].Id;
            var mini = categories[3].Id;

            await db.Products.AddRangeAsync(
                new Product { Name = "Bánh kem dâu tây", Price = 350000, SalePrice = 299000, CategoryId = birthday, Image = "cake1.svg", Description = "Bánh kem vani mềm mịn, phủ dâu tây tươi và kem sữa." },
                new Product { Name = "Bánh kem chocolate", Price = 390000, SalePrice = 339000, CategoryId = birthday, Image = "cake2.svg", Description = "Cốt bánh chocolate đậm vị kết hợp lớp kem chocolate mềm mượt." },
                new Product { Name = "Bánh kem hoa hồng", Price = 450000, SalePrice = 399000, CategoryId = love, Image = "cake3.svg", Description = "Thiết kế hoa hồng trang nhã, phù hợp sinh nhật và kỷ niệm." },
                new Product { Name = "Bánh kem tình yêu", Price = 420000, SalePrice = 369000, CategoryId = love, Image = "cake4.svg", Description = "Bánh kem hình trái tim với hương vani và dâu tây." },
                new Product { Name = "Mousse xoài", Price = 320000, SalePrice = 279000, CategoryId = mousse, Image = "cake5.svg", Description = "Mousse xoài chua ngọt, mát lạnh và thơm vị trái cây." },
                new Product { Name = "Mousse matcha", Price = 340000, SalePrice = 299000, CategoryId = mousse, Image = "cake6.svg", Description = "Mousse matcha thanh nhẹ, phù hợp cho người yêu vị trà xanh." },
                new Product { Name = "Mousse chocolate", Price = 360000, SalePrice = 319000, CategoryId = mousse, Image = "cake7.svg", Description = "Lớp mousse chocolate mịn mượt với vị cacao đậm đà." },
                new Product { Name = "Bánh mini dâu", Price = 180000, SalePrice = 159000, CategoryId = mini, Image = "cake8.svg", Description = "Bánh kem mini xinh xắn, thích hợp làm quà tặng." },
                new Product { Name = "Bánh mini chocolate", Price = 190000, SalePrice = 169000, CategoryId = mini, Image = "cake9.svg", Description = "Bánh mini chocolate nhỏ gọn với trang trí dễ thương." },
                new Product { Name = "Bánh kem vanilla", Price = 330000, SalePrice = 289000, CategoryId = birthday, Image = "cake10.svg", Description = "Bánh vanilla truyền thống, vị ngọt dịu và thơm béo." },
                new Product { Name = "Bánh kem bắp", Price = 370000, SalePrice = 329000, CategoryId = birthday, Image = "cake11.svg", Description = "Cốt bánh mềm xốp kết hợp kem sữa và bắp ngọt." }
            );
        }

        if (!await db.Banners.AnyAsync())
        {
            await db.Banners.AddRangeAsync(
                new Banner { Name = "Ưu đãi bánh kem", Priority = 1, Image = "cake1.svg", Description = "Ưu đãi bánh kem trong tuần" },
                new Banner { Name = "Bánh mới mỗi ngày", Priority = 2, Image = "cake3.svg", Description = "Khám phá những mẫu bánh mới" }
            );
        }

        if (!await db.Blogs.AnyAsync())
        {
            await db.Blogs.AddRangeAsync(
                new Blog { Name = "Cách chọn bánh kem cho sinh nhật", Description = "Gợi ý lựa chọn kích thước, hương vị và kiểu trang trí phù hợp." },
                new Blog { Name = "Bảo quản bánh kem đúng cách", Description = "Một số lưu ý giúp bánh giữ được độ tươi ngon." }
            );
        }

        await db.SaveChangesAsync();
    }
}

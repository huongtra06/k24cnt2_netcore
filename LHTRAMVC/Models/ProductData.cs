using System.Text.Json;

namespace LHTRAMVC.Models
{
    public static class ProductData
    {
        private static readonly string filePath =
            Path.Combine(Directory.GetCurrentDirectory(), "products.json");

        // Lấy danh sách sản phẩm
        public static List<Product> GetProducts()
        {
            if (!File.Exists(filePath))
            {
                var products = new List<Product>
                {
                    new Product
                    {
                        Id = 1,
                        Name = "Bánh Trung Thu",
                        Price = 150000,
                        CreatedAt = DateTime.Now,
                        ImageUrl = "/images/banhtrungthu.jpg"
                    },

                    new Product
                    {
                        Id = 2,
                        Name = "Bánh Sinh Nhật",
                        Price = 300000,
                        CreatedAt = DateTime.Now,
                        ImageUrl = "/images/banhsinhnhat.jpg"
                    },

                    new Product
                    {
                        Id = 3,
                        Name = "Bánh Cuốn",
                        Price = 50000,
                        CreatedAt = DateTime.Now,
                        ImageUrl = "/images/banhcuon.jpg"
                    }
                };

                SaveProducts(products);

                return products;
            }

            string json = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<List<Product>>(json)
                   ?? new List<Product>();
        }

        // Lưu danh sách sản phẩm
        public static void SaveProducts(List<Product> products)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(products, options);

            File.WriteAllText(filePath, json);
        }
    }
}
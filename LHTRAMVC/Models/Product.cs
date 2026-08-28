namespace LHTRAMVC.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedAt { get; set; }

        public string ImageUrl { get; set; }
    }

    public static class ProductData
    {
        private static List<Product> products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Bánh Trung Thu",
                Price = 500000,
                CreatedAt = new DateTime(2026, 8, 20),
                ImageUrl = "/images/banh-trung-thu.jpg"
            },

            new Product
            {
                Id = 2,
                Name = "Bánh Sinh Nhật",
                Price = 700000,
                CreatedAt = new DateTime(2026, 8, 20),
                ImageUrl = "/images/banh-sinh-nhat.jpg"
            },

            new Product
            {
                Id = 3,
                Name = "Bánh Cuốn",
                Price = 550000,
                CreatedAt = new DateTime(2026, 8, 20),
                ImageUrl = "/images/banh-cuon.jpg"
            },

            new Product
            {
                Id = 4,
                Name = "Bánh Mì",
                Price = 550000,
                CreatedAt = new DateTime(2026, 8, 20),
                ImageUrl = "/images/banh-mi.jpg"
            }
        };

        public static List<Product> GetProducts()
        {
            return products;
        }

        public static void SaveProducts(List<Product> newProducts)
        {
            products = newProducts;
        }
    }
}
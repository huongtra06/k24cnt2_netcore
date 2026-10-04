using System.ComponentModel.DataAnnotations;

namespace LHTLesson14.Models;

public class Product
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm.")]
    [StringLength(100)]
    [Display(Name = "Tên sản phẩm")]
    public string Name { get; set; } = "";

    [Range(0, 999999999999, ErrorMessage = "Giá không hợp lệ.")]
    [Display(Name = "Giá niêm yết")]
    public decimal Price { get; set; }

    [Range(0, 999999999999, ErrorMessage = "Giá khuyến mãi không hợp lệ.")]
    [Display(Name = "Giá khuyến mãi")]
    public decimal SalePrice { get; set; }

    public byte Status { get; set; } = 1;

    [Display(Name = "Danh mục")]
    public int CategoryId { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Today;
    public string? Image { get; set; }

    [StringLength(500)]
    [Display(Name = "Mô tả")]
    public string? Description { get; set; }

    public Category? Category { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace LHTLesson14.Models;

public class Category
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập tên danh mục.")]
    [StringLength(100)]
    [Display(Name = "Tên danh mục")]
    public string Name { get; set; } = "";

    public byte Status { get; set; } = 1;
    public DateTime CreatedDate { get; set; } = DateTime.Today;
    public string? Image { get; set; }

    [StringLength(500)]
    [Display(Name = "Mô tả")]
    public string? Description { get; set; }

    public List<Product> Products { get; set; } = new();
}

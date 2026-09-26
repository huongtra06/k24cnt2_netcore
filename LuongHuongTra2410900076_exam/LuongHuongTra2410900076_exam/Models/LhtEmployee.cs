using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuongHuongTra2410900076_exam.Models;

[Table("LhtEmployee")]
public class LhtEmployee
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    [Display(Name = "Họ và tên")]
    public string LhtName { get; set; } = string.Empty;

    [StringLength(20)]
    [Display(Name = "Giới tính")]
    public string? LhtGender { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Ngày sinh")]
    public DateTime? LhtBirthDay { get; set; }

    [EmailAddress]
    [StringLength(150)]
    [Display(Name = "Email")]
    public string? LhtEmail { get; set; }

    [StringLength(20)]
    [Display(Name = "Số điện thoại")]
    public string? LhtPhone { get; set; }

    [Display(Name = "Hoạt động")]
    public bool LhtActive { get; set; }
}

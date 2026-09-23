using System.ComponentModel.DataAnnotations;

namespace LHTRALesson09.Models;

public class Account
{
    public int Id { get; set; }

    [Display(Name = "Họ và tên")]
    [Required(ErrorMessage = "Họ và tên không được để trống")]
    [StringLength(100, ErrorMessage = "Họ và tên tối đa 100 ký tự")]
    public string FullName { get; set; } = "";

    [Display(Name = "Địa chỉ Email")]
    [Required(ErrorMessage = "Địa chỉ Email không được để trống")]
    [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
    public string Email { get; set; } = "";

    [Display(Name = "Số điện thoại")]
    [Required(ErrorMessage = "Số điện thoại không được để trống")]
    [Phone(ErrorMessage = "Số điện thoại không đúng định dạng")]
    public string Phone { get; set; } = "";

    [Display(Name = "Địa chỉ thường trú")]
    [Required(ErrorMessage = "Địa chỉ thường trú không được để trống")]
    public string Address { get; set; } = "";

    [Display(Name = "Ảnh đại diện")]
    public string? Avatar { get; set; }

    [Display(Name = "Ngày sinh")]
    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Ngày sinh không được để trống")]
    public DateTime BirthDate { get; set; } = new DateTime(2000, 1, 1);

    [Display(Name = "Giới tính")]
    [Required(ErrorMessage = "Giới tính không được để trống")]
    public string Gender { get; set; } = "Nam";

    [Display(Name = "Mật khẩu")]
    [DataType(DataType.Password)]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự")]
    public string? Password { get; set; }

    [Display(Name = "Link Facebook cá nhân")]
    [Url(ErrorMessage = "Link Facebook không đúng định dạng")]
    public string? FacebookUrl { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}

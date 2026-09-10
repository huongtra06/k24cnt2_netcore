using System.ComponentModel.DataAnnotations;

namespace LQThangLesson4.Models
{
    public class TvCAccount
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui long nhap ho ten")]
        [Display(Name = "Ho ten")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Vui long nhap email")]
        [EmailAddress(ErrorMessage = "Email khong hop le")]
        [Display(Name = "Email")]
        public string Email { get; set; } = "";

        [Display(Name = "So dien thoai")]
        public string Phone { get; set; } = "";

        [Display(Name = "Anh dai dien")]
        public string Avatar { get; set; } = "";

        [Display(Name = "Dia chi")]
        public string Address { get; set; } = "";

        [Display(Name = "Gioi thieu")]
        public string Bio { get; set; } = "";

        [Display(Name = "Gioi tinh")]
        public string Gender { get; set; } = "";

        [Display(Name = "Ngay sinh")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
    }
}
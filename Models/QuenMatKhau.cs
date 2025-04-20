using System.ComponentModel.DataAnnotations;

namespace QuanLyKaraoke.Models
{
    public class QuenMatKhau
    {
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại hoặc email.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Số điện thoại không hợp lệ.")]
        [StringLength(15, ErrorMessage = "Số điện thoại không được vượt quá 15 ký tự.")]
        public string? SoDienThoai { get; set; }

        [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
        [StringLength(50, ErrorMessage = "Email không được vượt quá 50 ký tự.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu mới.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải từ 6 đến 100 ký tự.")]
        public string MatKhauMoi { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập lại mật khẩu mới.")]
        [Compare("MatKhauMoi", ErrorMessage = "Mật khẩu mới và nhập lại mật khẩu không khớp.")]
        public string NhapLaiMatKhauMoi { get; set; }
    }
}

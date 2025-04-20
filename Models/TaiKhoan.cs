using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKaraoke.Models
{
    public class TaiKhoan
    {
        [Key]
        public int MaTaiKhoan { get; set; }

        [Required, StringLength(50)]
        public string TenDangNhap { get; set; }

        [Required, StringLength(100)]
        public string MatKhau { get; set; }

        [Required]
        public string VaiTro { get; set; } = "User"; // Đổi thành string, mặc định là "User"

        [Required, StringLength(100)]
        public string HoTen { get; set; }

        [EmailAddress]
        [StringLength(50)]
        public string? Email { get; set; }

        [Required, RegularExpression(@"^[0-9]+$")]
        [StringLength(15)]
        public string SoDienThoai { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Vui lòng nhập lại mật khẩu.")]
        [Compare("MatKhau", ErrorMessage = "Mật khẩu và nhập lại mật khẩu không khớp.")]
        public string NhapLaiMatKhau { get; set; }
    }
}

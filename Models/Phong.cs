using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKaraoke.Models;

public class Phong
{
    [Key]
    public int MaPhong { get; set; }

    [Required]
    [Display(Name = "Số phòng")]
    public int SoPhong { get; set; }

    [Required]
    [Display(Name = "Loại phòng")]
    [RegularExpression(@"^(Phòng thường nhỏ|Phòng thường|Phòng VIP|Phòng SuperVIP)$", 
        ErrorMessage = "Loại phòng không hợp lệ.")]
    public string LoaiPhong { get; set; }

    [Required]
    [Display(Name = "Trạng thái")]
    public TrangThaiPhong TrangThai { get; set; } = TrangThaiPhong.Trong;

    [Required(ErrorMessage = "Vui lòng nhập giá (9h-18h).")]
    [Display(Name = "Giá (9h-18h)")]
    [Column(TypeName = "decimal(18, 0)")]
    [Range(0, double.MaxValue, ErrorMessage = "Giá phải là số dương.")]
    public decimal Gia9hDen18h { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập giá (18h-24h).")]
    [Display(Name = "Giá (18h-24h)")]
    [Column(TypeName = "decimal(18,0)")]
    [Range(0, double.MaxValue, ErrorMessage = "Giá phải là số dương.")]
    public decimal Gia18hDen24h { get; set; }

    [Display(Name = "Ngày cập nhật giá")]
    public DateTime NgayCapNhat { get; set; } = DateTime.Now;
}

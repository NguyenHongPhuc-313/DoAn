using System.ComponentModel.DataAnnotations;

public class NhanVien
{
    [Key]
    public int MaNV { get; set; }

    [Required, StringLength(100)]
    public string HoTen { get; set; }

    [Required]
    [RegularExpression(@"^(Quản lý|Lễ tân|Phục vụ)$")]
    public string ChucVu { get; set; }

    [Required, RegularExpression(@"^[0-9]+$")]
    [StringLength(10)]
    public string SoDienThoai { get; set; }

    [Required]
    public DateTime NgayTuyenDung { get; set; }
}

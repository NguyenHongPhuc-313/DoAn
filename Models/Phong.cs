using System.ComponentModel.DataAnnotations;

public class Phong
{
    [Key]
    public int MaPhong { get; set; }

    [Required]
    public int SoPhong { get; set; }

    [Required]
    [RegularExpression(@"^(Thường|VIP|Luxury)$")]
    public string LoaiPhong { get; set; }

    [Range(0, double.MaxValue)]
    public decimal GiaMoiGio { get; set; }

    [Required]
    [RegularExpression(@"^(Trống|Đang sử dụng|Bảo trì)$")]
    public string TrangThai { get; set; } = "Trống";
}

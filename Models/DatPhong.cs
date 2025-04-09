using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class DatPhong
{
    [Key]
    public int MaDatPhong { get; set; }

    [Required]
    public int MaKhachHang { get; set; }

    [ForeignKey("MaKhachHang")]
    public KhachHang? KhachHang { get; set; }

    [Required]
    public int MaPhong { get; set; }

    [ForeignKey("MaPhong")]
    public Phong? Phong { get; set; }

    [Required]
    public int MaNV { get; set; }

    [ForeignKey("MaNV")]
    public NhanVien? NhanVien { get; set; }

    [Required]
    public DateTime ThoiGianBatDau { get; set; }

    [Required]
    public DateTime ThoiGianKetThuc { get; set; }

    [Range(0, double.MaxValue)]
    public decimal TongTien { get; set; }
}

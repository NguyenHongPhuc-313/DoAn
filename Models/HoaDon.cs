using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class HoaDon
{
    [Key]
    public int MaHoaDon { get; set; }

    [Required]
    public int MaDatPhong { get; set; }

    [ForeignKey("MaDatPhong")]
    public DatPhong? DatPhong { get; set; }

    [Range(0, double.MaxValue)]
    public decimal TongSoTien { get; set; }

    [Required]
    [RegularExpression(@"^(Tiền mặt|Thẻ|Di động)$")]
    public string PhuongThucThanhToan { get; set; }

    [Required]
    [RegularExpression(@"^(Chờ duyệt|Đã thanh toán|Hủy)$")]
    public string TrangThaiThanhToan { get; set; } = "Chờ duyệt";

    public DateTime NgayXuat { get; set; } = DateTime.Now;
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ChiTietDichVu
{
    [Key]
    public int MaChiTiet { get; set; }

    [Required]
    public int MaDatPhong { get; set; }

    [ForeignKey("MaDatPhong")]
    public DatPhong? DatPhong { get; set; }

    [Required]
    public int MaDichVu { get; set; }

    [ForeignKey("MaDichVu")]
    public DichVu? DichVu { get; set; }

    [Range(1, int.MaxValue)]
    public int SoLuong { get; set; }

    [Range(0, double.MaxValue)]
    public decimal ThanhTien { get; set; }
}

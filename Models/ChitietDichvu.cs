using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QuanLyKaraoke.Models;

namespace QuanLyKaraoke.Models;
public class ChiTietDichVu
{
    [Key]
    public int MaChiTietDichVu { get; set; }

    [Required]
    public int MaDatPhong { get; set; }

    [Required]
    public int MaDichVu { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0")]
    public int SoLuong { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal DonGia { get; set; }

    // Navigation properties
    [ForeignKey("MaDatPhong")]
    public DatPhong? DatPhong { get; set; }

    [ForeignKey("MaDichVu")]
    public DichVu? DichVu { get; set; }
}

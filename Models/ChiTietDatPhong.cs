using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKaraoke.Models
{
    public class ChiTietDatPhong
    {
        [Key]
        public int MaChiTiet { get; set; }

        [Required]
        public int MaDatPhong { get; set; }

        [Required]
        public int MaDichVu { get; set; }

        [Required]
        public int SoLuong { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal DonGia { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ThanhTien { get; set; }

        // Navigation properties
        [ForeignKey("MaDatPhong")]
        public DatPhong DatPhong { get; set; }

        [ForeignKey("MaDichVu")]
        public DichVu DichVu { get; set; }
    }
} 
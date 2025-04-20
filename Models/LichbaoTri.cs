using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QuanLyKaraoke.Models;

public class LichBaoTri
{
    [Key]
    public int MaBaoTri { get; set; }

    [Required]
    public int MaPhong { get; set; }

    [ForeignKey("MaPhong")]
    public Phong? Phong { get; set; }

    [Required]
    public DateTime ThoiGianBatDau { get; set; }

    [Required]
    public DateTime ThoiGianKetThuc { get; set; }

    [StringLength(500)]
    public string? MoTa { get; set; }
}

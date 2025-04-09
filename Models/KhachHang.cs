using System.ComponentModel.DataAnnotations;

public class KhachHang
{
    [Key]
    public int MaKhachHang { get; set; }

    [Required, StringLength(100)]
    public string HoTen { get; set; }

    [Required, RegularExpression(@"^[0-9]+$")]
    [StringLength(15)]
    public string SoDienThoai { get; set; }

    [EmailAddress]
    [StringLength(50)]
    public string? Email { get; set; }
}

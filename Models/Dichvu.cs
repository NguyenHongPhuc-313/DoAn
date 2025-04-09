using System.ComponentModel.DataAnnotations;

public class DichVu
{
    [Key]
    public int MaDichVu { get; set; }

    [Required, StringLength(100)]
    public string TenDichVu { get; set; }

    [Required]
    [RegularExpression(@"^(Đồ ăn|Đồ uống|Khác)$")]
    public string DanhMuc { get; set; }

    [Range(0, double.MaxValue)]
    public decimal Gia { get; set; }

    public bool CoSan { get; set; } = true;
}

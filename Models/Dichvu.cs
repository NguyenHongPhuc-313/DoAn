using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKaraoke.Models
{
    public class DichVu
    {
        [Key]
        public int MaDichVu { get; set; }

        [Required(ErrorMessage = "Tên dịch vụ không được để trống")]
        [StringLength(100)]
        [Display(Name = "Tên dịch vụ")]
        public string TenDichVu { get; set; }

        [Required(ErrorMessage = "Danh mục là bắt buộc")]
        [RegularExpression("^(Đồ ăn|Đồ uống|Khác)$", ErrorMessage = "Danh mục không hợp lệ")]
        public string DanhMuc { get; set; }

        [Required(ErrorMessage = "Giá không được để trống")]
        [Column(TypeName = "decimal(18,0)")]
        [Display(Name = "Giá")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá phải là số dương")]
        public decimal Gia { get; set; }

        [Required(ErrorMessage = "Đơn vị tính không được để trống")]
        [StringLength(20)]
        [Display(Name = "Đơn vị tính")]
        public string DonViTinh { get; set; }

        public bool CoSan { get; set; } = true;

        public string? HinhAnh { get; set; }
    }
}

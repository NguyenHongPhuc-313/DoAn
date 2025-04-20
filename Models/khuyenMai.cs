using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace QuanLyKaraoke.Models;
public class KhuyenMai
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Tên khuyến mãi không được để trống")]
    public string TenKhuyenMai { get; set; }

    [Display(Name = "Hóa đơn tối thiểu")]
    public decimal? HoaDonToiThieu { get; set; }
    [Display(Name = "Hóa đơn tối đa")]
    public decimal? HoaDonToiDa { get; set; }
    [DataType(DataType.Date)]
    [Display(Name = "Ngày bắt đầu")]
    public DateTime NgayBatDau { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Ngày kết thúc")]
    public DateTime NgayKetThuc { get; set; }

    [Display(Name = "Phần trăm giảm giá")]
    [Range(0, 100, ErrorMessage = "Vui lòng nhập từ 0 đến 100")]
    public int PhanTramGiam { get; set; }
    public string? NoiDung { get; set; }
    [Display(Name = "Hình ảnh")]
    public string? HinhAnh { get; set; }

    [NotMapped] // 💥 Dòng này là để tránh EF Core cố gắng map thuộc tính này vào DB
    [Display(Name = "Upload ảnh")]
    public IFormFile? HinhAnhFile { get; set; }
}

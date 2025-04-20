using System.ComponentModel.DataAnnotations;
namespace QuanLyKaraoke.Models;
public enum TrangThaiPhong
{
    [Display(Name = "Trống")]
    Trong,

    [Display(Name = "Đang sử dụng")]
    DangSuDung,

    [Display(Name = "Đang bảo trì")]
    DangBaoTri,
    
    [Display(Name = "Đã đặt")]
    DaDat
}
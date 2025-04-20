using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyKaraoke.Data;
using QuanLyKaraoke.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace QuanLyKaraoke.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            // Lấy thống kê
            ViewBag.TongSoPhong = _context.Phongs.Count();
            ViewBag.PhongDangSuDung = _context.Phongs.Count(p => p.TrangThai == TrangThaiPhong.DangSuDung);
            
            // Lấy đặt phòng hôm nay
            var today = DateTime.Today;
            ViewBag.DatPhongHomNay = _context.DatPhongs
                .Count(dp => dp.ThoiGianBatDau.Date == today);
            
            // Tính doanh thu hôm nay
            ViewBag.DoanhThuHomNay = _context.DatPhongs
                .Where(dp => dp.ThoiGianBatDau.Date == today)
                .Sum(dp => dp.TongTien);
            
            // Lấy danh sách đặt phòng gần đây
            ViewBag.DatPhongGanDay = _context.DatPhongs
                .Include(dp => dp.Phong)
                .OrderByDescending(dp => dp.ThoiGianBatDau)
                .Take(10)
                .ToList();

            return View();
        }

        public IActionResult Phong()
        {
            var phongs = _context.Phongs.ToList();
            return View(phongs);
        }

        public IActionResult DatPhong()
        {
            var datPhongs = _context.DatPhongs
                .OrderByDescending(d => d.ThoiGianBatDau)
                .ToList();
            return View(datPhongs);
        }

        public IActionResult TaiKhoan()
        {
            var taiKhoans = _context.TaiKhoans.ToList();
            return View(taiKhoans);
        }

        // Quản lý dịch vụ
        public IActionResult DichVu()
        {
            var dichVus = _context.DichVus.ToList();
            return View(dichVus);
        }

        [HttpPost]
        public IActionResult AddService(DichVu dichVu, IFormFile uploadedFile)
        {
            if (ModelState.IsValid)
            {
                // Xử lý upload ảnh
                if (uploadedFile != null && uploadedFile.Length > 0)
                {
                    var fileName = Path.GetFileName(uploadedFile.FileName);
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "dichvu", uniqueFileName);
                    
                    using (var stream = new System.IO.FileStream(filePath, FileMode.Create))
                    {
                        uploadedFile.CopyTo(stream);
                    }
                    
                    dichVu.HinhAnh = "/images/dichvu/" + uniqueFileName;
                }

                _context.DichVus.Add(dichVu);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false, message = "Có lỗi xảy ra khi thêm dịch vụ" });
        }

        [HttpPost]
        public IActionResult UpdateService(DichVu dichVu, IFormFile uploadedFile)
        {
            if (ModelState.IsValid)
            {
                var existingDichVu = _context.DichVus.Find(dichVu.MaDichVu);
                if (existingDichVu == null)
                {
                    return Json(new { success = false, message = "Không tìm thấy dịch vụ" });
                }

                // Xử lý upload ảnh mới
                if (uploadedFile != null && uploadedFile.Length > 0)
                {
                    // Xóa ảnh cũ nếu có
                    if (!string.IsNullOrEmpty(existingDichVu.HinhAnh))
                    {
                        var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", existingDichVu.HinhAnh.TrimStart('/'));
                        if (System.IO.File.Exists(oldFilePath))
                        {
                            System.IO.File.Delete(oldFilePath);
                        }
                    }

                    // Lưu ảnh mới
                    var fileName = Path.GetFileName(uploadedFile.FileName);
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "dichvu", uniqueFileName);
                    
                    using (var stream = new System.IO.FileStream(filePath, FileMode.Create))
                    {
                        uploadedFile.CopyTo(stream);
                    }
                    
                    dichVu.HinhAnh = "/images/dichvu/" + uniqueFileName;
                }
                else
                {
                    // Giữ nguyên ảnh cũ nếu không upload ảnh mới
                    dichVu.HinhAnh = existingDichVu.HinhAnh;
                }

                // Cập nhật thông tin dịch vụ
                existingDichVu.TenDichVu = dichVu.TenDichVu;
                existingDichVu.DanhMuc = dichVu.DanhMuc;
                existingDichVu.Gia = dichVu.Gia;
                existingDichVu.CoSan = dichVu.CoSan;
                existingDichVu.HinhAnh = dichVu.HinhAnh;

                _context.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false, message = "Có lỗi xảy ra khi cập nhật dịch vụ" });
        }

        [HttpPost]
        public IActionResult DeleteService(int id)
        {
            var dichVu = _context.DichVus.Find(id);
            if (dichVu == null)
            {
                return Json(new { success = false, message = "Không tìm thấy dịch vụ" });
            }

            // Xóa ảnh nếu có
            if (!string.IsNullOrEmpty(dichVu.HinhAnh))
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", dichVu.HinhAnh.TrimStart('/'));
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }

            _context.DichVus.Remove(dichVu);
            _context.SaveChanges();
            return Json(new { success = true });
        }
    }

    public class AdminDashboardViewModel
    {
        public int TotalRooms { get; set; }
        public int TotalBookings { get; set; }
        public int TotalUsers { get; set; }
        public List<DatPhong> RecentBookings { get; set; }
    }
} 
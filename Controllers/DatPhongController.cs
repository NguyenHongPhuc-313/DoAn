using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyKaraoke.Models;
using QuanLyKaraoke.Data;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace QuanLyKaraoke.Controllers
{
    public class DatPhongController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DatPhongController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DatPhong/Create
        public async Task<IActionResult> Create()
        {
            // Lấy danh sách phòng và nhân viên để hiển thị trong dropdown
            ViewBag.MaPhong = new SelectList(await _context.Phongs.ToListAsync(), "MaPhong", "TenPhong");
            ViewBag.NhanViens = await _context.NhanViens.ToListAsync();
            
            // Lấy danh sách loại phòng từ bảng phòng
            var loaiPhongs = await _context.Phongs
                .Select(p => p.LoaiPhong)
                .Distinct()
                .ToListAsync();

            // Nếu không có dữ liệu, sử dụng danh sách mặc định
            if (loaiPhongs == null || loaiPhongs.Count == 0)
            {
                loaiPhongs = new List<string>
                {
                    "Phòng thường nhỏ",
                    "Phòng thường",
                    "Phòng VIP",
                    "Phòng SuperVIP"
                };
            }

            ViewBag.LoaiPhongs = loaiPhongs;

            // Lấy danh sách dịch vụ từ database
            ViewBag.DichVus = _context.DichVus.ToList();

            return View();
        }

        // GET: DatPhong/GetRoomPrice
        public async Task<IActionResult> GetRoomPrice(string roomType)
        {
            if (string.IsNullOrEmpty(roomType))
            {
                return Json(new { error = "Vui lòng chọn loại phòng" });
            }

            // Lấy thông tin giá từ phòng
            var phong = await _context.Phongs
                .Where(p => p.LoaiPhong == roomType)
                .FirstOrDefaultAsync();

            if (phong == null)
            {
                return Json(new { error = "Không tìm thấy thông tin giá cho loại phòng này" });
            }

            return Json(new {
                gia9hDen18h = phong.Gia9hDen18h,
                gia18hDen24h = phong.Gia18hDen24h
            });
        }

        // POST: DatPhong/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string HoTen, string SoDienThoai, string Email, 
            [Bind("MaPhong,MaNV,ThoiGianBatDau,ThoiGianKetThuc")] DatPhong datPhong)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Kiểm tra và tạo khách hàng mới
                    var khachHang = await _context.KhachHangs
                        .FirstOrDefaultAsync(kh => kh.SoDienThoai == SoDienThoai);

                    if (khachHang == null)
                    {
                        khachHang = new KhachHang
                        {
                            HoTen = HoTen,
                            SoDienThoai = SoDienThoai,
                            Email = Email
                        };
                        _context.KhachHangs.Add(khachHang);
                        await _context.SaveChangesAsync();
                    }

                    datPhong.MaKhachHang = khachHang.MaKhachHang;

                    // Kiểm tra phòng có tồn tại không
                    var phong = await _context.Phongs.FindAsync(datPhong.MaPhong);
                    if (phong == null)
                    {
                        ModelState.AddModelError("", "Phòng không tồn tại");
                        return View(datPhong);
                    }

                    // Kiểm tra nhân viên có tồn tại không
                    var nhanVien = await _context.NhanViens.FindAsync(datPhong.MaNV);
                    if (nhanVien == null)
                    {
                        ModelState.AddModelError("", "Nhân viên không tồn tại");
                        return View(datPhong);
                    }

                    // Kiểm tra thời gian đặt phòng có hợp lệ không
                    if (datPhong.ThoiGianBatDau < DateTime.Now)
                    {
                        ModelState.AddModelError("", "Thời gian bắt đầu không được nhỏ hơn thời gian hiện tại");
                        return View(datPhong);
                    }

                    if (datPhong.ThoiGianKetThuc <= datPhong.ThoiGianBatDau)
                    {
                        ModelState.AddModelError("", "Thời gian kết thúc phải lớn hơn thời gian bắt đầu");
                        return View(datPhong);
                    }

                    // Kiểm tra phòng có bị trùng lịch không
                    var isPhongTrung = await _context.DatPhongs
                        .AnyAsync(dp => dp.MaPhong == datPhong.MaPhong &&
                            ((dp.ThoiGianBatDau <= datPhong.ThoiGianBatDau && dp.ThoiGianKetThuc > datPhong.ThoiGianBatDau) ||
                            (dp.ThoiGianBatDau < datPhong.ThoiGianKetThuc && dp.ThoiGianKetThuc >= datPhong.ThoiGianKetThuc) ||
                            (dp.ThoiGianBatDau >= datPhong.ThoiGianBatDau && dp.ThoiGianKetThuc <= datPhong.ThoiGianKetThuc)));

                    if (isPhongTrung)
                    {
                        ModelState.AddModelError("", "Phòng đã được đặt trong khoảng thời gian này");
                        return View(datPhong);
                    }

                    // Tính số giờ hát
                    var thoiGianHat = (datPhong.ThoiGianKetThuc - datPhong.ThoiGianBatDau).TotalHours;
                    
                    // Tính tổng tiền dựa trên khung giờ
                    decimal tongTien = 0;
                    var gioBatDau = datPhong.ThoiGianBatDau.Hour;
                    var gioKetThuc = datPhong.ThoiGianKetThuc.Hour;

                    if (gioBatDau < 18 && gioKetThuc <= 18)
                    {
                        // Toàn bộ thời gian trong khung 9h-18h
                        tongTien = phong.Gia9hDen18h * (decimal)thoiGianHat;
                    }
                    else if (gioBatDau >= 18)
                    {
                        // Toàn bộ thời gian trong khung 18h-24h
                        tongTien = phong.Gia18hDen24h * (decimal)thoiGianHat;
                    }
                    else
                    {
                        // Thời gian trải dài cả 2 khung giờ
                        var gioTrongKhung1 = 18 - gioBatDau;
                        var gioTrongKhung2 = gioKetThuc - 18;
                        tongTien = (phong.Gia9hDen18h * (decimal)gioTrongKhung1) + 
                                 (phong.Gia18hDen24h * (decimal)gioTrongKhung2);
                    }

                    datPhong.TongTien = tongTien;

                    // Cập nhật trạng thái phòng
                    phong.TrangThai = TrangThaiPhong.DaDat;
                    _context.Phongs.Update(phong);

                    _context.DatPhongs.Add(datPhong);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Đặt phòng thành công!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Có lỗi xảy ra khi đặt phòng: " + ex.Message);
                    return View(datPhong);
                }
            }

            ViewData["MaPhong"] = new SelectList(_context.Phongs, "MaPhong", "TenPhong", datPhong.MaPhong);
            return View(datPhong);
        }

        // GET: DatPhong
        public async Task<IActionResult> Index()
        {
            var datPhongs = await _context.DatPhongs
                .Include(dp => dp.Phong)
                .Include(dp => dp.KhachHang)
                .Include(dp => dp.NhanVien)
                .OrderByDescending(dp => dp.ThoiGianBatDau)
                .ToListAsync();
            return View(datPhongs);
        }

        // GET: DatPhong/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datPhong = await _context.DatPhongs
                .Include(dp => dp.Phong)
                .Include(dp => dp.KhachHang)
                .Include(dp => dp.NhanVien)
                .FirstOrDefaultAsync(m => m.MaDatPhong == id);

            if (datPhong == null)
            {
                return NotFound();
            }

            return View(datPhong);
        }
    }
} 
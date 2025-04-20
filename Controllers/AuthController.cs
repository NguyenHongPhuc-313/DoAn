using Microsoft.AspNetCore.Mvc;
using QuanLyKaraoke.Data;
using QuanLyKaraoke.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace QuanLyKaraoke.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult DangKy()
        {
            ViewData["Layout"] = null;
            return View();
        }

        [HttpPost]
        public IActionResult DangKy(TaiKhoan model)
        {
            if (ModelState.IsValid)
            {
                if (model.VaiTro == "Admin")
                {
                    ModelState.AddModelError("VaiTro", "Không thể đăng ký tài khoản Admin.");
                    return View(model);
                }

                model.MatKhau = BCrypt.Net.BCrypt.HashPassword(model.MatKhau);
                _context.TaiKhoans.Add(model);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Đăng ký thành công! Vui lòng đăng nhập.";
                return RedirectToAction("DangNhap");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult DangNhap()
        {
            ViewData["Layout"] = null;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DangNhap(string tenDangNhap, string matKhau)
        {
            var taiKhoan = _context.TaiKhoans.FirstOrDefault(x => x.TenDangNhap == tenDangNhap);

            if (taiKhoan == null || !BCrypt.Net.BCrypt.Verify(matKhau, taiKhoan.MatKhau))
            {
                TempData["ErrorMessage"] = "Tên đăng nhập hoặc mật khẩu không đúng";
                return View();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, taiKhoan.TenDangNhap),
                new Claim(ClaimTypes.Role, taiKhoan.VaiTro),
                new Claim("HoTen", taiKhoan.HoTen),
                new Claim("MaTaiKhoan", taiKhoan.MaTaiKhoan.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1)
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            if (taiKhoan.VaiTro == "Admin")
            {
                return RedirectToAction("Dashboard", "Admin");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> DangXuat()
        {
            // Xóa tất cả các cookie
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            
            // Xóa session
            HttpContext.Session.Clear();
            
            // Chuyển hướng về trang chủ
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult QuenMatKhau()
        {
            ViewData["Layout"] = null;
            return View();
        }

        [HttpPost]
        public IActionResult QuenMatKhau(QuenMatKhau model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.MatKhauMoi != model.NhapLaiMatKhauMoi)
            {
                ModelState.AddModelError("NhapLaiMatKhauMoi", "Mật khẩu nhập lại không khớp.");
                return View(model);
            }

            var taiKhoan = _context.TaiKhoans
                .FirstOrDefault(t => t.SoDienThoai == model.SoDienThoai || t.Email == model.Email);

            if (taiKhoan == null)
            {
                ModelState.AddModelError(string.Empty, "Không tìm thấy tài khoản với thông tin đã cung cấp.");
                return View(model);
            }

            taiKhoan.MatKhau = BCrypt.Net.BCrypt.HashPassword(model.MatKhauMoi);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Đổi mật khẩu thành công! Vui lòng đăng nhập.";
            return RedirectToAction("DangNhap");
        }
    }
}
